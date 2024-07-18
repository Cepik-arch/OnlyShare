using OnlyShare.Database.Models;

namespace OnlyShare.Contracts.Answer
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; } //Date created or updated based on request type

        public string Title { get; set; } = string.Empty;

        public string AnswerBody { get; set; } = string.Empty;

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
