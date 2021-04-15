using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Email is required fields")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Logn is required fields")]
        public string Password { get; set; }
    }
}
