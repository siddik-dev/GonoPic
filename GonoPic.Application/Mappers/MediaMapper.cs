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
                CategoryId = media.CategoryId,
                TagIds = media.Tags?.Select(t => t.TagId).ToList() ?? new List<int>()
            };
        }

        public static Media ToEntity(MediaCreateDto dto, string uploadedById)
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
                CategoryId = dto.CategoryId,
                Tags = dto.TagIds.Select(tagId => new MediaTag { TagId = tagId }).ToList()
            };
        }

        public static void UpdateEntity(MediaUpdateDto dto, Media media)
        {
            media.Title = dto.Title;
            media.Description = dto.Description;
            media.Price = dto.Price;
            media.Type = dto.Type;
            media.FilePath = dto.FilePath;
            media.ThumbnailPath = dto.ThumbnailPath;
            media.CategoryId = dto.CategoryId;
            media.Tags = dto.TagIds.Select(tagId => new MediaTag { TagId = tagId }).ToList();
        }   
    }
}
