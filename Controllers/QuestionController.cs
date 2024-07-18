using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlyShare.Contracts.Answer;
using OnlyShare.Contracts.Question;
using OnlyShare.Database.Models;
using OnlyShare.Database.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace OnlyShare.Controllers
{

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAnswerRepository _answerRepository;

        public QuestionController(IQuestionRepository questionRepository, IUserRepository userRepository, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _userRepository = userRepository;
            _answerRepository = answerRepository;
        }

        [HttpGet]
        public ActionResult Index(int counter)
        {
            var questions = _questionRepository.GetFiveMoreQuestions(counter);
            return Json(questions);
        }

        [HttpGet("[action]")]
        public ActionResult Detail(Guid id)
        {
            var question = _questionRepository.GetQuestionById(id);

            return Json(question);
        }

        [HttpGet("[action]")]
        public ActionResult Tags()
        {
            return Json(Enum.GetValues(typeof(Tag)));
        }

        [HttpPost("[action]")]
        public ActionResult SearchTag(SearchTagRequest request)
        {
            if (!Enum.IsDefined(typeof(Tag),request.SearchTag))
            {
                return BadRequest($"{request.SearchTag} is not defined Tag.");
            }

            var questions = _questionRepository.GetQuestions()
                .Where(x => x.Tags.Contains(request.SearchTag));

            return Json(questions);
        }

        [HttpPost("[action]")]
        public ActionResult Search(SearchRequest request)
        {
            if (string.IsNullOrEmpty(request.Term))
            {
                return Json(_questionRepository.GetQuestions());
            }

            var questions = _questionRepository.GetSearchQuestions(request.Term);

            return Json(questions);
        }

        [HttpPost("[action]")]
        public ActionResult Create(QuestionRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(request);
            
            /*Get userId*/
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if(user == null)
            {
                return Unauthorized();
            }

            var question = new Question();
            question.Id = Guid.NewGuid();
            question.Title = request.Title;
            question.QuestionBody = request.QuestionBody;
            question.DateCreated = DateTime.Now;
            question.DateUpdated = DateTime.Now;
            question.UserId = user.Id;
            question.User = user;
            question.Tags = request.Tags;

            _questionRepository.CreateQuestion(question);

            return Ok(question.Id);
        }

        [HttpPost("[action]")]
        public ActionResult Edit(QuestionEditRequest request)
        {
            var question = _questionRepository.GetQuestionById(request.Id);

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

            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if (user == null || user.Id != question.UserId)
            {
                return Unauthorized();
            }

            question.Title = request.Title;
            question.QuestionBody = request.QuestionBody;
            question.Tags = request.Tags;
            question.DateUpdated = DateTime.Now;

            _questionRepository.EditQuestion(question);

            var questionResponse = new QuestionResponse
            {
                Id = question.Id,
                UserId = user.Id,
                Title = question.Title,
                Date = question.DateUpdated,
                AnswerBody = question.QuestionBody,
                Tags = question.Tags
            };

            return Json(questionResponse);
        }

        [HttpPost("[action]")]
        public ActionResult Delete(AnswerIdRequest request)
        {
            var question = _questionRepository.GetQuestionById(request.Id);

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

            var user = _userRepository.GetUserById(Guid.Parse(userId));

            if (user == null || user.Id != question.UserId)
            {
                return Unauthorized();
            }

            _questionRepository.DeleteQuestion(question);

            return Ok("Deleted successfully");
        }

        [HttpPost("[action]")]
        public ActionResult ApproveAnswer(AnswerIdRequest request)
        {
            var answer = _answerRepository.GetAnswerById(request.Id);
            if (!ModelState.IsValid || answer == null)
            {
                return BadRequest(request);
            }
            var question = _questionRepository.GetQuestionById(answer.QuestionId);
            if(question == null)
            {
                return BadRequest("Question doesnt exist");
            }

            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = _userRepository.GetUserById(Guid.Parse(userId));
            if (user == null || user.Id != question.UserId)
            {
                return Unauthorized();
            }

            answer.IsApproved = true;
            question.IsApproved = true;
            _questionRepository.EditQuestion(question);
            _answerRepository.EditAnswer(answer);

            return Ok("Answer and question approved");
        }

        [HttpPost("[action]")]
        public ActionResult UnapproveAnswer(AnswerIdRequest request)
        {
            var answer = _answerRepository.GetAnswerById(request.Id);
            if (!ModelState.IsValid || answer == null)
            {
                return BadRequest(request);
            }
            var question = _questionRepository.GetQuestionById(answer.QuestionId);
            if (question == null)
            {
                return BadRequest("Question doesnt exist");
            }

            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var userId = handler.ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = _userRepository.GetUserById(Guid.Parse(userId));
            if (user == null || user.Id != question.UserId)
            {
                return Unauthorized();
            }

            answer.IsApproved = false;
            question.IsApproved = false;
            _questionRepository.EditQuestion(question);
            _answerRepository.EditAnswer(answer);

            return Ok("Answer and question unapproved");
        }

    }
}
