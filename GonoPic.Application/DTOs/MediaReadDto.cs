using GonoPic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.DTOs
{
    public class MediaReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public MediaType Type { get; set; }

        public string FilePath { get; set; } = string.Empty;

        public string ThumbnailPath { get; set; } = string.Empty;

        public DateTime UploadedAt { get; set; }

        public string UploadedById { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        public List<int> TagIds { get; set; } = new();
    }
}
