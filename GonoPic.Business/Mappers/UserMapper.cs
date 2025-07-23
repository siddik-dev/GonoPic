using GonoPic.Business.DTOs;
using GonoPic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Business.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsCreator = user.IsCreator,
                CreatedAt = user.CreatedAt
            };
        }

        public static User ToEntity(UserCreateDto dto)
        {
            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };
        }

        public static void UpdateEntity(User user, UserUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.FirstName))
            {
                user.FirstName = dto.FirstName;
            }
            
            if (!string.IsNullOrWhiteSpace(dto.LastName))
            {
                user.LastName = dto.LastName;
            }

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                user.Email = dto.Email;
            }

            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                user.PasswordHash = HashPassword(dto.Password);
            }
        }

        private static string HashPassword(string password)
        {
            // Simple placeholder. Replace with real hashing (e.g., BCrypt).
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
