using GonoPic.Domain.Entities;
using GonoPic.Domain.Interfaces;
using GonoPic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace GonoPic.Infrastructure.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly GonoPicDbContext _dbContext;

        public MediaRepository(GonoPicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Media>> GetAllAsync()
        {
            return await _dbContext.Media
                .Include(m => m.Categories)
                .Include(m => m.Tags)
                .ToListAsync();
        }

        public async Task<Media?> GetByIdAsync(int id)
        {
            return await _dbContext.Media
                .Include(m => m.Categories)
                .Include(m => m.Tags)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Media>> GetByUserIdAsync(string userId)
        {
            return await _dbContext.Media
                .Include(m => m.Categories)
                .Include(m => m.Tags)
                .Where(m => m.UploadedById == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Media media)
        {
            await _dbContext.Media
                .AddAsync(media);
        }

        public void Update(Media media)
        {
            _dbContext.Media
                .Update(media);
        }

        public void Remove(Media media)
        {
            _dbContext.Media
                .Remove(media);
        }
    }
}
