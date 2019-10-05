using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeManagement.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(255)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public string Avatar { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [MaxLength(255)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(255)]
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}