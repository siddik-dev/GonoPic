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
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllUsers();
            var userDtos = users.Select(UserMapper.ToDto);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) 
                return NotFound();

            var userDto = UserMapper.ToDto(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateDto dto)
        {
            var user = UserMapper.ToEntity(dto);
            await _userService.CreateUser(user);
            
            var userDto = UserMapper.ToDto(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, userDto);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Update(int id, UserUpdateDto dto)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) 
                return NotFound();

            UserMapper.UpdateEntity(user, dto);
            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            await _userService.DeleteUser(id);
            return NoContent();
        }

    }
}
