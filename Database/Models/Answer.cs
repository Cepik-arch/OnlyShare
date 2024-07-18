using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlyShare.Database.Models
{
    public class Answer
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } = new User();

        [JsonIgnore]
        public Question Question { get; set; } = new Question();

        public string AnswerBody { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsApproved { get; set; } = false;

        public int Votes { get; set; }
        public ICollection<UserVote> AnswerVotes { get; set; } = new List<UserVote>();
    }
}
