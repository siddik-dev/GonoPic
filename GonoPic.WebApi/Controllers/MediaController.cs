using GonoPic.Application.DTOs;
using GonoPic.Application.Interfaces;
using GonoPic.Application.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GonoPic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mediaList = await _mediaService.GetAllMediaAsync();
            var mediaDtos = mediaList.Select(MediaMapper.ToDto);
            return Ok(mediaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var media = await _mediaService.GetMediaByIdAsync(id);
            if (media == null)
                return NotFound();
            var mediaDto = MediaMapper.ToDto(media);
            return Ok(mediaDto);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(string userId)
        {
            var mediaList = await _mediaService.GetMediaByUserIdAsync(userId);
            var mediaDtos = mediaList.Select(MediaMapper.ToDto);
            return Ok(mediaDtos);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(MediaCreateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var mediaEntity = MediaMapper.ToEntity(dto, userId);
            await _mediaService.CreateMediaAsync(mediaEntity);
            return Ok(new { message = "Media added successfully" });
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, MediaUpdateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var media = await _mediaService.GetMediaByIdAsync(id);
            if (media == null)
                return NotFound();
            if (media.UploadedById != userId)
                return Forbid();
            MediaMapper.UpdateEntity(dto, media);
            await _mediaService.UpdateMediaAsync(media);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var media = await _mediaService.GetMediaByIdAsync(id);
            if (media == null)
                return NotFound();
            if (media.UploadedById != userId)
                return Forbid();
            await _mediaService.DeleteMediaAsync(media);
            return NoContent();
        }
    }
}
