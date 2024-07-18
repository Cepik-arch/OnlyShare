using System.ComponentModel.DataAnnotations;

namespace OnlyShare.Contracts.User
{
    public class ChangeUserNameRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; } = string.Empty;
    }
}
