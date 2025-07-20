using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Data.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MediaTag> MediaTags { get; set; }
    }
}
