using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Data.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaType Type { get; set; } // Enum: Photo, Audio, Video
        public string FilePath { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime UploadedAt { get; set; }

        public int UploadedByUserId { get; set; }
        public User UploadedBy { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<MediaTag> Tags { get; set; }
    }

}

public enum MediaType
{
    Photo,
    Audio,
    Video
}
