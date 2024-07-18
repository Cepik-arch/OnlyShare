namespace OnlyShare.Contracts.Answer
{
    public class AnswerVoteResponse
    {
        public Guid AnswerId { get; set; }
        public Guid UserId { get; set; }
        public bool? IsUpVoted { get; set; }
    }
}
