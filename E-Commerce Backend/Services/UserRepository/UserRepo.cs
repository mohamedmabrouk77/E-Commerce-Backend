using E_Commerce_Backend.AppDbContext;
using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Services.UserRepository
{
    public class UserRepo : IUserRepo
    {
        private readonly dbcontext _context;

        public UserRepo(dbcontext context)
        {
            _context = context;
        }

        public void Add(RegisterDto dto)
        {
            var result = new User
            {
                UserName = dto.UserName,
                UserPassword = dto.UserPassword,
                UserEmailAddress = dto.UserEmailAddress,
                Role = dto.Role,
            };
            _context.Users.Add(result);
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(x=>x.UserEmailAddress == email);
        }
    }
}
