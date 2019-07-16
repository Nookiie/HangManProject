using HM.Data.Abstraction;
using HM.Data.Entities.Users.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities.Users
{
    public class User : BaseEntity<Guid>
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username needs to have more characters")]
        [MaxLength(20, ErrorMessage = "Username has reached max characters")]
        public string Username { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Password needs to have more characters")]
        [MaxLength(30, ErrorMessage = "Password has reached max characters")]
        public string Password { get; set; }

        [MinLength(5, ErrorMessage = "Email needs to have more characters")]
        [MaxLength(50, ErrorMessage = "Email has reached max characters")]
        public string Email { get; set; }

        [DefaultValue(Role.User)]
        public Role Role { get; set; }

        [DefaultValue(0)]
        public int Score { get; set; }

        [DefaultValue(0)]   
        public int HighestStreak { get; set; }
        
        public string Token { get; set; }
    }
}
