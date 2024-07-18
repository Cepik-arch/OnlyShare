using Microsoft.EntityFrameworkCore;
using OnlyShare.Database.Models;

namespace OnlyShare.Database.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DataContext _context;

        public AnswerRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateAnswer(Answer answer)
        {
            _context.Add(answer);
            _context.SaveChanges();
        }

        public void DeleteAnswer(Answer answer)
        {
            _context.Remove(answer);
            _context.SaveChanges();
        }

        public void EditAnswer(Answer answer)
        {
            _context.Update(answer);
            _context.SaveChanges();
        }

        public Answer? GetAnswerById(Guid id) =>
            _context.Answers
                .Include(x => x.User)
                .Include(x => x.AnswerVotes)
                .FirstOrDefault(x => x.Id == id);

        public void DeleteVote(UserVote vote)
        {
            _context.Remove(vote);
            _context.SaveChanges();
        }

        public bool IsAnswered(Guid questionId, Guid userId) => 
            _context.Answers
                .Any(x => x.UserId == userId && x.QuestionId == questionId);
    }
}