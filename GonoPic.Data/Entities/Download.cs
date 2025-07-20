using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Data.Entities
{
    public class Download
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int MediaId { get; set; }
        public Media Media { get; set; }

        public DateTime DownloadedAt { get; set; }
    }

}
