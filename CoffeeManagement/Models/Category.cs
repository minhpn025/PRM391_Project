using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeManagement.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(255)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}