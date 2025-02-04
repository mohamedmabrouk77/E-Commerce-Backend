using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
