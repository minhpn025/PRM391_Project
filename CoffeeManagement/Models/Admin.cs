using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoffeeManagement.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int id { get; set; }

        [Required, MaxLength(255)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(255)]
        public string Fullname { get; set; }

        [Required, MaxLength(255)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(255)]
        public string Address { get; set; }
    }
}