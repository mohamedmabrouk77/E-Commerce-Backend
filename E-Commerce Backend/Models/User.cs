using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required]
        public string Role { get; set; }

        //Relation With Order
        public List<Order> Order { get; set; }
    }
}
