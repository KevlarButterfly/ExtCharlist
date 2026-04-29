using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExtCharlistLibrary.DTO
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is required")][Length(8,15, ErrorMessage ="Password must be between 8 and 15 characters")] public string Password { get; set; }
        [Required(ErrorMessage ="Email is required")][RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage ="Invalid email format")] public string Email { get; set; }
        public UserRole UserRole { get; set; }
    }
}
