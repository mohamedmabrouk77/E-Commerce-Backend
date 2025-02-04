using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Dtos
{
    public class LoginDto
    {
        [EmailAddress]
        public string UserEmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
