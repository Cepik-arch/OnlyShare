namespace OnlyShare.Database.Models
{
    public class UserVote
    {
        public Guid Id { get; set; }

        public Guid AnswerId { get; set; }

        public Guid UserId { get; set; }

        public bool IsUpvote { get; set; }

    }
}
