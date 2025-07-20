using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GonoPic.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsCreator { get; set; } // true if user uploads content
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Media> UploadedMedia { get; set; }
        public ICollection<Download> Downloads { get; set; }
    }

}
