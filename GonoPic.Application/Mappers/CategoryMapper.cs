using GonoPic.Application.DTOs;
using GonoPic.Domain.Entities;


namespace GonoPic.Application.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public static Category ToEntity(CategoryCreateDto dto)
        {
            return new Category()
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }

        public static void UpdateEntity(CategoryUpdateDto dto, Category category)
        {
            category.Name = dto.Name;
            category.Description = dto.Description;
        }
    }
}
