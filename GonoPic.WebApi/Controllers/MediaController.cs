using GonoPic.Application.DTOs;
using GonoPic.Application.Interfaces;
using GonoPic.Application.Mappers;
using GonoPic.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace GonoPic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MediaController(IMediaService mediaService, UserManager<ApplicationUser> userManager)
        {
            _mediaService = mediaService;
            _userManager = userManager;
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
            
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(MediaCreateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var mediaEntity = MediaMapper.ToEntity(dto, userId);

            var result = await _mediaService.CreateMediaAsync(mediaEntity);
            if (!result)
                return BadRequest(new { message = "Failed to create media" });

            // Promoting user to Contributor role
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Contributor") && !roles.Contains("Editor") && !roles.Contains("Admin"))
            {
                await _userManager.AddToRoleAsync(user, "Contributor");
            }

            return Ok(new { message = "Media added successfully" });        
        }

        [HttpPost("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, MediaUpdateDto dto)
        {
            var media = await _mediaService.GetMediaByIdAsync(id);
            if (media == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (media.UploadedById != userId)
                return Forbid();

            MediaMapper.UpdateEntity(dto, media);

            var result = await _mediaService.UpdateMediaAsync(media);
            if (!result)
                return BadRequest(new { message = "Failed to update media" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var media = await _mediaService.GetMediaByIdAsync(id);
            if (media == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (media.UploadedById != userId)
                return Forbid();

            var result = await _mediaService.DeleteMediaAsync(media);
            if (!result)
                return BadRequest(new { message = "Failed to de;ete media" });

            return NoContent();
        }
    }
}
