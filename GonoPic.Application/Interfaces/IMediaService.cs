using GonoPic.Application.DTOs;
using GonoPic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.Interfaces
{
    public interface IMediaService
    {
        Task<IEnumerable<Media>> GetAllMediaAsync();
        Task<Media?> GetMediaByIdAsync(int id);
        Task<IEnumerable<Media>> GetMediaByUserIdAsync(string userId);
        Task CreateMediaAsync(Media media);
        Task UpdateMediaAsync(Media media);
        Task DeleteMediaAsync(Media media);
    }
}
