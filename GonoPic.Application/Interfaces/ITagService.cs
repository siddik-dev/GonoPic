using GonoPic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag?> GetTagByIdAsync(int id);
        Task<IEnumerable<Tag>> GetTagsByNamesAsync(IEnumerable<string> names);
        Task<bool> CreateAllTagsAsync(IEnumerable<Tag> tags);
        Task<IEnumerable<Tag>> ProcessTagsAsync(IEnumerable<string> tagNames);
    }
}
