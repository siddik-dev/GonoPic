using GonoPic.Application.DTOs;
using GonoPic.Application.Interfaces;
using GonoPic.Application.Mappers;
using GonoPic.Domain.Entities;
using GonoPic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await _unitOfWork.TagRepository.GetAllAsync();
        }

        public async Task<Tag?> GetTagByIdAsync(int id)
        {
            return await _unitOfWork.TagRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetTagsByNamesAsync(IEnumerable<string> names)
        {
            return await _unitOfWork.TagRepository.GetByNamesAsync(names);
        }

        public async Task<bool> CreateAllTagsAsync(IEnumerable<Tag> tags)
        {
            await _unitOfWork.TagRepository.AddAllAsync(tags);
            var rowsAffected = await _unitOfWork.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Tag>> ProcessTagsAsync(IEnumerable<string> tagNames)
        {
            var cleanedNames = tagNames
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrEmpty(t))
                .Distinct()
                .ToList();

            var existingTagNames = (await GetTagsByNamesAsync(cleanedNames))
                .Select(t => t.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var newTags = cleanedNames
                .Where(name => !existingTagNames.Contains(name))
                .Select(name => TagMapper.ToEntity(new TagCreateDto { Name = name }))
                .ToList();

            if (newTags.Any())
                await CreateAllTagsAsync(newTags);

            return await GetTagsByNamesAsync(cleanedNames);
        }
    }
}
