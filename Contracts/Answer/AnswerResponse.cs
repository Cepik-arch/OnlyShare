namespace OnlyShare.Contracts.Answer
{
    public class AnswerResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; } //Date created or updated based on request type

        public string AnswerBody { get; set; } = string.Empty;
    }
}
