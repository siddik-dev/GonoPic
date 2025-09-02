using GonoPic.Domain.Entities;
using GonoPic.Domain.Interfaces;
using GonoPic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly GonoPicDbContext _dbContext;

        public TagRepository(GonoPicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _dbContext.Tags
                .Include(t => t.MediaItems)
                .ToListAsync();
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _dbContext.Tags
                .Include(t => t.MediaItems)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tag>> GetByNamesAsync(IEnumerable<string> names)
        {
            var nameSet = names.ToHashSet();

            return await _dbContext.Tags
                .Where(t => nameSet.Contains(t.Name))
                .ToListAsync();
        }

        public async Task AddAllAsync(IEnumerable<Tag> tags)
        {
            await _dbContext.Tags
                .AddRangeAsync(tags);
        }
    }
}
