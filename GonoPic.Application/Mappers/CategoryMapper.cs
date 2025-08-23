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
            };
        }

        public static Category ToEntity(CategoryCreateDto dto)
        {
            return new Category()
            {
                Name = dto.Name
            };
        }

        public static void UpdateEntity(CategoryUpdateDto dto, Category category)
        {
            category.Name = dto.Name;
        }
    }
}
