using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Request
{
    public class LoginRequest
    {
        [Required]
        [MinLength(6)]
        [MaxLength(12)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string Password = string.Empty;
    }
}
