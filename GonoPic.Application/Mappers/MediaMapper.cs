using GonoPic.Application.DTOs;
using GonoPic.Domain.Entities;


namespace GonoPic.Application.Mappers
{
    public static class MediaMapper
    {
        public static MediaDto ToDto(Media media)
        {
            return new MediaDto()
            {
                Id = media.Id,
                Title = media.Title,
                Description = media.Description,
                Price = media.Price,
                Type = media.Type,
                FilePath = media.FilePath,
                ThumbnailPath = media.ThumbnailPath,
                UploadedAt = media.UploadedAt,
                UploadedById = media.UploadedById,
                CategoryIds = media.Categories?.Select(c => c.Id).ToList() ?? new List<int>(),
                TagIds = media.Tags?.Select(t => t.Id).ToList() ?? new List<int>()
            };
        }

        public static Media ToEntity(MediaCreateDto dto, string uploadedById, IEnumerable<Category> categories)
        {
            return new Media
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                Type = dto.Type,
                FilePath = dto.FilePath,
                ThumbnailPath = dto.ThumbnailPath,
                UploadedById = uploadedById,
                Categories = categories.ToList(),
                Tags = dto.TagIds.Select(tagId => new MediaTag { TagId = tagId }).ToList()
            };
        }

        public static void UpdateEntity(MediaUpdateDto dto, Media media, IEnumerable<Category> categories)
        {
            media.Title = dto.Title;
            media.Description = dto.Description;
            media.Price = dto.Price;
            media.Type = dto.Type;
            media.FilePath = dto.FilePath;
            media.ThumbnailPath = dto.ThumbnailPath;
            media.Categories = categories.ToList();
            media.Tags = dto.TagIds.Select(tagId => new MediaTag { TagId = tagId }).ToList();
        }   
    }
}
