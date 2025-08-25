using GonoPic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Domain.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public MediaType Type { get; set; } // Enum: Photo, Audio, Video
        public string FilePath { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public string UploadedById { get; set; } = default!;
        
        public ICollection<Category> Categories { get; set; }

        public ICollection<MediaTag> Tags { get; set; }
    }

}


