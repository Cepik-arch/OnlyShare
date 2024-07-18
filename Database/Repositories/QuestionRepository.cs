using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlyShare.Database.Models;
using System.Linq;

namespace OnlyShare.Database.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;

        public QuestionRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateQuestion(Question question)
        {
            _context.Add(question);
            _context.SaveChanges();
        }
        public void EditQuestion(Question question)
        {
            _context.Update(question);
            _context.SaveChanges();
        }

        public void DeleteQuestion(Question question)
        {
            _context.Remove(question);
            _context.SaveChanges();
        }

        public IEnumerable<Question> GetFiveMoreQuestions(int counter) => 
            _context.Questions
            .Include(x => x.User)
            .Include(x => x.Answers)
            .ThenInclude(a => a.User)
            .OrderByDescending(x => x.DateCreated)
            .Take(5*counter)
            .ToList();

        public Question? GetQuestionById(Guid id) =>
            _context.Questions
                .Include(x => x.User)
                .Include(x => x.Answers)
                    .ThenInclude(a => a.User)
                .Include(x => x.Answers)
                    .ThenInclude(a => a.AnswerVotes)
                .FirstOrDefault(x => x.Id == id);

        public IEnumerable<Question> GetQuestions() => 
            _context.Questions
            .Include(x => x.User)
            .Include(x => x.Answers)
            .ThenInclude(a => a.User)
            .OrderByDescending(x => x.DateCreated)
            .ToList();

        public IEnumerable<Question> GetSearchQuestions(string term) =>
            _context.Questions
                .Include(x => x.User)
                .Include(x => x.Answers)
                .Where(q => EF.Functions.Like(q.Title, $"%{term}%") || EF.Functions.Like(q.QuestionBody, $"%{term}%"))
                .ToList();
    }
}
