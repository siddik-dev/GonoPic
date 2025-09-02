using GonoPic.Application.Interfaces;
using GonoPic.Domain.Interfaces;
using GonoPic.Infrastructure.Data;


namespace GonoPic.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GonoPicDbContext _context;
        public IMediaRepository MediaRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ITagRepository TagRepository { get; }

        public UnitOfWork(GonoPicDbContext context, IMediaRepository mediaRepository, ICategoryRepository categoryRepository, ITagRepository tagRepository)
        {
            _context = context;
            MediaRepository = mediaRepository;
            CategoryRepository = categoryRepository;
            TagRepository = tagRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
