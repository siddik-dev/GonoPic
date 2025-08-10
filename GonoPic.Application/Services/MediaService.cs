using GonoPic.Application.DTOs;
using GonoPic.Application.Interfaces;
using GonoPic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.Services
{
    public class MediaService : IMediaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MediaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Media>> GetAllMediaAsync()
        {
            return await _unitOfWork.MediaRepository.GetAllAsync();
        }

        public async Task<Media?> GetMediaByIdAsync(int id)
        {
            return await _unitOfWork.MediaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Media>> GetMediaByUserIdAsync(string userId)
        {
            return await _unitOfWork.MediaRepository.GetByUserIdAsync(userId);
        }

        public async Task CreateMediaAsync(Media media)
        {
            await _unitOfWork.MediaRepository.AddAsync(media);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMediaAsync(Media media)
        {
            _unitOfWork.MediaRepository.Update(media);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMediaAsync(Media media)
        {
            _unitOfWork.MediaRepository.Remove(media);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
