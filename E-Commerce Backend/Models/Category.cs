using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        //Relation With Product
        public List<Product> Product { get; set; }
    }
}
