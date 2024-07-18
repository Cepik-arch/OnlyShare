using System.ComponentModel.DataAnnotations;

namespace OnlyShare.Contracts.User
{
    public class RegisterRequest
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 8)]
        public string PasswordRepeat { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;
    }
}
