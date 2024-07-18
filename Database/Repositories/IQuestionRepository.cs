using OnlyShare.Database.Models;

namespace OnlyShare.Database.Repositories
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetFiveMoreQuestions(int counter);
        IEnumerable<Question> GetQuestions();
        IEnumerable<Question> GetSearchQuestions(string term);
        Question? GetQuestionById(Guid id);
        void CreateQuestion(Question question);
        void EditQuestion(Question question);
        void DeleteQuestion(Question question);
    }
}
