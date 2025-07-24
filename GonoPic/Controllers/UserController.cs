using GonoPic.Business.DTOs;
using GonoPic.Business.Mappers;
using GonoPic.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var userDtos = users.Select(UserMapper.ToDto);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> Get(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) 
                return NotFound();

            var userDto = UserMapper.ToDto(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateDto dto)
        {
            var user = UserMapper.ToEntity(dto);
            await _userService.CreateUserAsync(user);
            
            var userDto = UserMapper.ToDto(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, userDto);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Update(int id, UserUpdateDto dto)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) 
                return NotFound();

            UserMapper.UpdateEntity(user, dto);
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpPost("{id}/update-email")]
        public async Task<ActionResult> UpdateEmail(int id, UserUpdateEmailDto dto)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            UserMapper.UpdateEmail(user, dto);
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpPost("{id}/update-password")]
        public async Task<ActionResult> UpdatePassword(int id, UserUpdatePasswordDto dto)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            UserMapper.UpdatePassword(user, dto);
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

    }
}
