using GonoPic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();     
        Task<Tag?> GetByIdAsync(int id);
        Task<IEnumerable<Tag>> GetByNamesAsync(IEnumerable<string> names);
        Task AddAllAsync(IEnumerable<Tag> tags);
    }
}
