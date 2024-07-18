using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using OnlyShare.Database.Models;
using OnlyShare.Database.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using OnlyShare.Contracts.User;

namespace OnlyShare.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;

        private readonly IOptions<AppSettings> _options;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AccountController(DataContext dataContext, IOptions<AppSettings> options, IUserRepository userRepository, IConfiguration config)
        {
            _dataContext = dataContext;
            _options = options;
            _userRepository = userRepository;
            _config = config;
        }

        [HttpPost("[action]")]
        public IActionResult Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (request.Password != request.PasswordRepeat)
                return BadRequest("Passwords does not match.");

            if (_dataContext.Users.Any(user => user.Email == request.Email))
                return BadRequest($"User with email address {request.Email} is already registered.");

            var (passwordSalt, passwordHash) = CreatePasswordHash(request.Password);

            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _dataContext.Add(user);
            _dataContext.SaveChanges();

            // send email here

            return Ok("User created");
        }

        private static (byte[] passwordSalt, byte[] passwordHash) CreatePasswordHash(string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return (passwordSalt, passwordHash);
        }

        [HttpPost("[action]")]
        public IActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _dataContext.Users.FirstOrDefault(user => request.Email == user.Email);

            if (user == null)
                return NotFound($"Incorrect email or password.");

            if (VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt) == false)
                return BadRequest("Incorrect email or password.");


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email)
        }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            if (tokenString == null)
                return BadRequest("Login failed.");

            return Ok(new LoginResponse { Token = tokenString });
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(storedHash));
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(storedSalt));

            using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (var i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i]) return false;
            }

            return true;
        }

        [HttpGet("[action]")]
        public IActionResult ReturnUser()
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            var userName = user.Username;
            var userEmail = user.Email;
            var id = user.Id;

            var userInfo = new
            {
                Email = userEmail,
                UserName = userName,
                Id = id
            };

            return Ok(userInfo);
        }

        [HttpPost("[action]")]
        public IActionResult ChangeUserName(ChangeUserNameRequest request)
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }


            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            user.Username = request.UserName;

            _userRepository.EditUser(user);
            return Ok("Změna jména úspěšná");
        }

        [HttpPost("[action]")]
        public IActionResult PasswordChange(ChangePasswordRequest request)
        {
            if (request.newPassword != request.confirmPassword)
            {
                return BadRequest("Password doesnt match");
            }
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            var isValidPassword = VerifyPasswordHash(request.currentPassword, user.PasswordHash, user.PasswordSalt);
            if (!isValidPassword)
            {
                return BadRequest("Incorrect actual password");
            }

            var (newPasswordSalt, newPasswordHash) = CreatePasswordHash(request.newPassword);

            user.PasswordSalt = newPasswordSalt;
            user.PasswordHash = newPasswordHash;

            _userRepository.EditUser(user);
            return Ok("Password changed");
        }


        [HttpPost("[action]")]
        public IActionResult SendPasswordThroughEmail(string userMail)
        {
            var user = _userRepository.GetUserByEmail(userMail);
            if(user == null)
            {
                return BadRequest("User not found");
            }

            var token = CreateRandomToken();

            var resetToken = new ResetToken
            {
                User = user,
                Token = token,
                ExpirationTime = DateTime.Now.AddMinutes(30)
            };

            _dataContext.Add(resetToken);
            _dataContext.SaveChanges();

            //Poslat email s tokenem
            var resetPasswordLink = GenerateResetPasswordLink(token);

            var fromEmail = _config["EmailSenderController:From"];
            var fromPassword = _config["EmailSenderController:Password"];
            var toEmail = userMail;
            var subject = "Forgot Password";
            var body = $"Hello, {user.Username}! Please click on the following link to reset your password: {resetPasswordLink}";

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("", fromEmail));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;
                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate(fromEmail, fromPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }

                return Ok("Email sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong with email");
            }
            
        }

        private string GenerateResetPasswordLink(string token)
        {
            var resetPasswordLink = new StringBuilder();
            resetPasswordLink.Append("https://cngroup-utb--2023-os-topujde.azurewebsites.net/reset-password/");
            resetPasswordLink.Append(token);

            return resetPasswordLink.ToString();
        }

        [HttpPost("[action]")]
        public IActionResult ResetPassword(ResetPasswordRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                return BadRequest("Password doesnt match");
            }
            var tokenValid = _dataContext.ResetTokens.FirstOrDefault(u => u.Token == request.Token);
            if (tokenValid == null || tokenValid.ExpirationTime < DateTime.Now)
            {
                return BadRequest("Token invalid");
            }

            var user = _userRepository.GetUserById(tokenValid.UserId);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var (newPasswordSalt, newPasswordHash) = CreatePasswordHash(request.Password);

            user.PasswordSalt = newPasswordSalt;
            user.PasswordHash = newPasswordHash;

            _userRepository.EditUser(user);
            return Ok("OK");
        }


        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
