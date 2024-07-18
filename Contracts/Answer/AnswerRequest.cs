using System.ComponentModel.DataAnnotations;

namespace OnlyShare.Contracts.Answer
{
    public class AnswerRequest
    {
        [Required]
        public Guid QuestionId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(3000, MinimumLength = 3)]
        public string AnswerBody { get; set; } = string.Empty;
    }
}
