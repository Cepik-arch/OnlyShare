using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlyShare.Contracts;
using OnlyShare.Contracts.Answer;
using OnlyShare.Database.Models;
using OnlyShare.Database.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace OnlyShare.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AnswerController : Controller
    {
        
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly DataContext _dataContext;
        public AnswerController(IAnswerRepository answerRepository, IUserRepository userRepository, IQuestionRepository questionRepository, DataContext dataContext)
        {
            _answerRepository = answerRepository;
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _dataContext = dataContext;
        }

        [HttpGet("[action]")]
        public IActionResult Detail(Guid id)
        {
            var answer = _answerRepository.GetAnswerById(id);

            if (!ModelState.IsValid || answer == null)
            {
                return BadRequest(id);
            }

            return Json(answer);
        }

        [HttpPost("[action]")]
        public ActionResult Create(AnswerRequest request)
        {
            var question = _questionRepository.GetQuestionById(request.QuestionId);

            if (!ModelState.IsValid || question == null)
            {
                return BadRequest(request);
            }

            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            if (_answerRepository.IsAnswered(question.Id,Guid.Parse(userId)))
            {
                return BadRequest("It looks like you've already answered this topic. If you need to update your answer or have any further comments, please edit your original response.");
            }

            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            var answer = new Answer();
            answer.Id = Guid.NewGuid();
            answer.AnswerBody = request.AnswerBody;
            answer.DateCreated = DateTime.Now;
            answer.DateUpdated = DateTime.Now;
            answer.UserId = user.Id;
            answer.User = user;
            answer.QuestionId = request.QuestionId;
            answer.Question = question;

            _answerRepository.CreateAnswer(answer);

            var answerResponse = new AnswerResponse {
                Id = answer.Id,
                UserId = user.Id,
                Date = answer.DateCreated,
                AnswerBody = answer.AnswerBody
            };

            return Json(answerResponse);
        }

        [HttpPost("[action]")]
        public ActionResult Edit(AnswerEditRequest request)
        {
            var answer = _answerRepository.GetAnswerById(request.Id);

            if (!ModelState.IsValid || answer == null)
            {
                return BadRequest(request);
            }

            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if (user == null || user.Id != answer.UserId)
            {
                return Unauthorized();
            }

            answer.AnswerBody = request.AnswerBody;
            answer.DateUpdated = DateTime.Now;

            _answerRepository.EditAnswer(answer);

            var answerResponse = new AnswerResponse
            {
                Id = answer.Id,
                UserId = user.Id,
                Date = answer.DateUpdated,
                AnswerBody = answer.AnswerBody
            };

            return Json(answerResponse);
        }

        [HttpPost("[action]")]
        public ActionResult Delete(AnswerIdRequest request)
        {
            var answer = _answerRepository.GetAnswerById(request.Id);

            if (!ModelState.IsValid || answer == null)
            {
                return BadRequest(request);
            }

            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if (user == null || user.Id != answer.UserId)
            {
                return Unauthorized();
            }

            _answerRepository.DeleteAnswer(answer);

            return Ok("Deleted successfully");
        }
        
        [HttpPost("[action]")]
        public ActionResult UpVote(AnswerIdRequest request)
        {
            Console.WriteLine(request);
            var answer = _answerRepository.GetAnswerById(request.Id);

            if (!ModelState.IsValid || answer == null)
            {
                return BadRequest(request);
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
            var existingVote = answer.AnswerVotes.FirstOrDefault(v => v.UserId == user.Id);

            if (existingVote == null)
            {
                var vote = new UserVote
                {
                    UserId = user.Id,
                    AnswerId = answer.Id,
                    IsUpvote = true
                };

                answer.AnswerVotes.Add(vote);
                answer.Votes += 1;
            }
            else if (existingVote.IsUpvote)
            {
                answer.Votes -= 1;
                _answerRepository.DeleteVote(existingVote);
            }
            else
            {
                existingVote.IsUpvote = true;
                answer.Votes += 2;
            }

            _answerRepository.EditAnswer(answer);

            var answerVote = new AnswerVoteResponse
            {
                AnswerId = answer.Id,
                UserId = user.Id,
                IsUpVoted = existingVote?.IsUpvote
            };

            return Json(answerVote);
        }

        [HttpPost("[action]")]
        public ActionResult DownVote(AnswerIdRequest request)
        {
            var answer = _answerRepository.GetAnswerById(request.Id);

            if (!ModelState.IsValid || answer == null)
            {
                return BadRequest(request);
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

            var existingVote = answer.AnswerVotes.FirstOrDefault(v => v.UserId == user.Id);

            if (existingVote == null)
            {
                var vote = new UserVote
                {
                    UserId = user.Id,
                    AnswerId = answer.Id,
                    IsUpvote = false
                };

                answer.AnswerVotes.Add(vote);
                answer.Votes -= 1;
            }
            else if (!existingVote.IsUpvote)
            {
                answer.Votes += 1;
                _answerRepository.DeleteVote(existingVote);
            }
            else
            {
                existingVote.IsUpvote = false;
                answer.Votes -= 2;
            }

            _answerRepository.EditAnswer(answer);

            var answerVote = new AnswerVoteResponse
            {
                AnswerId = answer.Id,
                UserId = user.Id,
                IsUpVoted = existingVote?.IsUpvote
            };

            return Json(answerVote);
        }

    }
}
