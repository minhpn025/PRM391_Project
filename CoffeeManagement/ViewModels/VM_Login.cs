using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeManagement.ViewModels
{
    public class VM_Login
    {
        [Required, MaxLength(255)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}