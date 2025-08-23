using GonoPic.Domain.Entities;


namespace GonoPic.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> GetByNameAsync(string name);
        Task AddAsync(Category category);
        void UpdateAsync(Category category);
        void RemoveAsync(Category category);
    }
}
