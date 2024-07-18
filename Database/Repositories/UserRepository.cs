using Azure.Core;
using OnlyShare.Database.Models;

namespace OnlyShare.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User? GetUserById(Guid Id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Id);

            return user;
        }

        public void EditUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(_x => _x.Email == email);
            return user;
        }
    }
}
