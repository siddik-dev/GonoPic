using GonoPic.Application.Interfaces;
using GonoPic.Application.Mappers;
using GonoPic.Application.Services;
using GonoPic.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GonoPic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tagList = await _tagService.GetAllTagsAsync();

            var tagDtos = tagList.Select(TagMapper.ToDto).ToList();
            return Ok(tagDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null)
                return NotFound();

            var tagDto = TagMapper.ToDto(tag);
            return Ok(tagDto);
        }

        [HttpGet("{id}/media")]
        public async Task<IActionResult> GetMediaByTag(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null)
                return NotFound();

            var mediaItems = tag.MediaItems ?? new List<Media>();
            if (mediaItems == null || !mediaItems.Any())
                return NotFound(new { Message = $"No media found with '{tag.Name}' tag." });

            var mediaDtos = mediaItems.Select(MediaMapper.ToDto);
            return Ok(mediaDtos);
        }
    }
}
