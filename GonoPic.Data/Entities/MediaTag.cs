using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Domain.Entities
{
    public class MediaTag
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public Media Media { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
