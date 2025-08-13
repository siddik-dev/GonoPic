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

        public async Task<bool> CreateMediaAsync(Media media)
        {
            await _unitOfWork.MediaRepository.AddAsync(media);
            var rowsAffected = await _unitOfWork.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateMediaAsync(Media media)
        {
            _unitOfWork.MediaRepository.Update(media);
            var rowsAffected = await _unitOfWork.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteMediaAsync(Media media)
        {
            _unitOfWork.MediaRepository.Remove(media);
            var rowsAffected = await _unitOfWork.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
