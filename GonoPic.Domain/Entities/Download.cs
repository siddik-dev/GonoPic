using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Domain.Entities
{
    public class Download
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;

        public int MediaId { get; set; }
        public Media Media { get; set; }

        public DateTime DownloadedAt { get; set; }
    }

}
