using GonoPic.Domain.Interfaces;


namespace GonoPic.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMediaRepository MediaRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
