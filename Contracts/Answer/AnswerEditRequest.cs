using System.ComponentModel.DataAnnotations;

namespace OnlyShare.Contracts.Answer
{
    public class AnswerEditRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(3000, MinimumLength = 3)]
        public string AnswerBody { get; set; } = string.Empty;
    }
}
