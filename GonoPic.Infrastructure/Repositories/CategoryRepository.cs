using GonoPic.Domain.Entities;
using GonoPic.Domain.Interfaces;
using GonoPic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace GonoPic.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GonoPicDbContext _dbContext;

        public CategoryRepository(GonoPicDbContext dbContext)
        {   
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories
                .Include(c => c.MediaItems)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
        }

        public void UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);
        }

        public void RemoveAsync(Category category)
        {
            _dbContext.Categories.Remove(category);
        }
    }
}
