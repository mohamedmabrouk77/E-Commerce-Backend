using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Services.UserRepository
{
    public interface IUserRepo
    {
        public User GetByEmail(string email);
        public void Add(RegisterDto dto);
    }
}
