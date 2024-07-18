using OnlyShare.Database.Models;

namespace OnlyShare.Database.Repositories
{
    public interface IUserRepository
    {
        User? GetUserById(Guid Id);

        void EditUser(User user);

        User? GetUserByEmail(string Email);
    }
}
