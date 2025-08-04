using GonoPic.Application.Interfaces;
using GonoPic.Infrastructure.Data;
using GonoPic.Application.Mappers;
using Microsoft.AspNetCore.Mvc;
using GonoPic.Application.DTOs;

namespace GonoPic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            var userDtos = users.Select(UserMapper.ToDTO);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> Get(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) 
                return NotFound();

            var userDto = UserMapper.ToDTO(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateDto dto)
        {
            var user = UserMapper.ToEntity(dto);
            await _userService.CreateUserAsync(user);
            
            var userDto = UserMapper.ToDTO(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, userDto);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Update(string id, UserUpdateDto dto)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) 
                return NotFound();

            UserMapper.UpdateEntity(user, dto);
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpPost("{id}/update-email")]
        public async Task<ActionResult> UpdateEmail(string id, UserUpdateEmailDto dto)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            UserMapper.UpdateEmail(user, dto);
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpPost("{id}/update-password")]
        public async Task<ActionResult> UpdatePassword(string id, UserUpdatePasswordDto dto)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            UserMapper.UpdatePassword(user, dto);
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

    }
}
