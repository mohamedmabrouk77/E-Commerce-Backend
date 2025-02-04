using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Models;
using E_Commerce_Backend.Services.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly IConfiguration _configuration;

        public UserController(IUserRepo repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public IActionResult SignUp([FromBody] RegisterDto dto)
        {
            dto.UserPassword = dto.UserPassword;
            _repo.Add(dto);
            if(dto == null)
            {
                return BadRequest("Enter Data Success");
            }
            return Ok(new { Message = "User Registered Successfully" });
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _repo.GetByEmail(dto.UserEmailAddress);
            if (user == null || dto.UserPassword != user.UserPassword)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
            var secretKey = _configuration["Jwt:Secret"];
            if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
            {
                throw new InvalidOperationException("JWT Secret is missing or too short. Must be at least 32 characters long.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.UserEmailAddress),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
