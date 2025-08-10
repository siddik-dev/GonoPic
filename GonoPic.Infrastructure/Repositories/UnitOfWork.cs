using GonoPic.Application.Interfaces;
using GonoPic.Domain.Interfaces;
using GonoPic.Infrastructure.Data;


namespace GonoPic.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GonoPicDbContext _context;
        public IMediaRepository MediaRepository { get; }

        public UnitOfWork(GonoPicDbContext context, IMediaRepository mediaRepository)
        {
            _context = context;
            MediaRepository = mediaRepository;
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
