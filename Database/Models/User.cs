using System.Text.Json.Serialization;

namespace OnlyShare.Database.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        [JsonIgnore]
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public List<Question> Questions = new List<Question>();

        public List<Answer> Answers = new List<Answer>();
    }
}
