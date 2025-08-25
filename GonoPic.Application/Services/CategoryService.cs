using GonoPic.Application.Interfaces;
using GonoPic.Domain.Entities;


namespace GonoPic.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<int> ids)
        {
            return await _unitOfWork.CategoryRepository.GetByIdsAsync(ids);
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _unitOfWork.CategoryRepository.GetByIdAsync(id);
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await _unitOfWork.CategoryRepository.GetByNameAsync(name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.AddAsync(category);
            var rowsAffected = await _unitOfWork.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            _unitOfWork.CategoryRepository.UpdateAsync(category);
            var rowsAffected = await _unitOfWork.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            _unitOfWork.CategoryRepository.RemoveAsync(category);
            var rowsAffected = await _unitOfWork.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
