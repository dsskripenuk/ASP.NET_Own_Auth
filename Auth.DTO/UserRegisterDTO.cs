using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth.DTO
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Email is required fields")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Logn is required fields")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Logn is required fields")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Logn is required fields")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Logn is required fields")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Logn is required fields")]
        [Range(15, 100, ErrorMessage = "Age range from 15 to 100")]
        public int Age { get; set; }
    }
}
