using GonoPic.Domain.Interfaces;


namespace GonoPic.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMediaRepository MediaRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
