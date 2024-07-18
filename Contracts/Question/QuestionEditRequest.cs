using OnlyShare.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlyShare.Contracts.Question
{
    public class QuestionEditRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [StringLength(3000, MinimumLength = 3)]
        public string QuestionBody { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}