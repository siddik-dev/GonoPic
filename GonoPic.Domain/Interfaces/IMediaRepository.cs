using GonoPic.Domain.Entities;


namespace GonoPic.Domain.Interfaces
{
    public interface IMediaRepository
    {
        Task<IEnumerable<Media>> GetAllAsync();
        Task<Media?> GetByIdAsync(int id);
        Task<IEnumerable<Media>> GetByUserIdAsync(string userId);
        Task AddAsync (Media media);
        void Update (Media media);
        void Remove (Media media);
    }
}
