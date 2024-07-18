namespace OnlyShare.Database.Models
{
    public class Question
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } = new User();

        public string Title { get; set; }  = string.Empty;

        public string QuestionBody { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<Answer> Answers { get; set; } = new List<Answer>();

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public bool IsApproved { get; set; } = false;
    }
}
