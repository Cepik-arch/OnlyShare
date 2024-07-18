using System.ComponentModel.DataAnnotations;

namespace OnlyShare.Contracts.User
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        [StringLength(50, MinimumLength = 8)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
