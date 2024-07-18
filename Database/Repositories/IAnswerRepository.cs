using OnlyShare.Database.Models;

namespace OnlyShare.Database.Repositories
{
    public interface IAnswerRepository
    {
        void CreateAnswer(Answer answer);

        void EditAnswer(Answer answer);

        void DeleteAnswer(Answer answer);

        Answer? GetAnswerById(Guid id);

        void DeleteVote(UserVote vote);

        bool IsAnswered(Guid questionId, Guid userId);
    }
}
