using LoginApi.Data;
using LoginApi.Models;

namespace LoginApi.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool Exists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
    }
}