namespace OnlyShare.Database.Models
{
    public class ResetToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = new User();
        public string Token { get; set; } = String.Empty;
        public DateTime ExpirationTime { get; set; }
    }
}
