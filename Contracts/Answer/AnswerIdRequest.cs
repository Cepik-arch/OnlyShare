using System.ComponentModel.DataAnnotations;

namespace OnlyShare.Contracts.Answer
{
    public class AnswerIdRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
