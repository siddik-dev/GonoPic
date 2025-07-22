using GonoPic.Business.Services.Interfaces;
using GonoPic.Data.Entities;
using GonoPic.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.Add(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}
