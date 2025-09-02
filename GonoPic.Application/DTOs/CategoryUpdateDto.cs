using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.DTOs
{
    public class CategoryUpdateDto
    {
        [Required, StringLength(100)]
        public string Name {  get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
