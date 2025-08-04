using GonoPic.Application.DTOs;
using GonoPic.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.Mappers
{
    public static class UserMapper
    {
        public static UserReadDto ToDTO(ApplicationUser user)
        {
            return new UserReadDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsCreator = user.IsCreator,
                CreatedAt = user.CreatedAt
            };
        }

        public static ApplicationUser ToEntity(UserCreateDto dto)
        {
            return new ApplicationUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };
        }

        public static void UpdateEntity(ApplicationUser user, UserUpdateDto dto)
        {
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
        }

        public static void UpdateEmail(ApplicationUser user, UserUpdateEmailDto dto)
        {
            user.Email = dto.Email;
        }

        public static void UpdatePassword(ApplicationUser user, UserUpdatePasswordDto dto)
        {
            user.PasswordHash = HashPassword(dto.Password);
        }

        private static string HashPassword(string password)
        {
            // Simple placeholder. Replace with real hashing (e.g., BCrypt).
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
