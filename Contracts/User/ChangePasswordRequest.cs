using System.ComponentModel.DataAnnotations;

namespace OnlyShare.Contracts.User
{
    public class ChangePasswordRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string currentPassword { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 8)]
        public string newPassword { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false), Compare("newPassword")]
        [StringLength(50, MinimumLength = 8)]
        public string confirmPassword { get; set; } = string.Empty;
    }
}
