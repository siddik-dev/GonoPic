using GonoPic.Application.DTOs;
using GonoPic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GonoPic.Application.Mappers
{
    public static class TagMapper
    {
        public static TagDto ToDto(Tag tag)
        {
            return new TagDto
            {
                Id = tag.Id,
                Name = tag.Name,
            };
        }

        public static Tag ToEntity(TagCreateDto dto)
        {
            return new Tag
            {
                Name = dto.Name,
            };
        }
    }
}
