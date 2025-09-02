using GonoPic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.DTOs
{
    public class MediaUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        [Required]
        public MediaType Type { get; set; } // Enum: Photo, Audio, Video

        [Required]
        public string FilePath { get; set; } = string.Empty;

        public string ThumbnailPath { get; set; } = string.Empty;

        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();

        public IEnumerable<string> TagNames { get; set; } = new List<string>();
    }
}
