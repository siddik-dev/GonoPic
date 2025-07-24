using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.DTOs
{
    public class UserUpdatePasswordDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
