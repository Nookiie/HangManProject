using AutoMapper;
using HM.AppServices.DTOs;
using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HM.WebAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Word, WordDTO>();
            CreateMap<Category, GameTrackerDTO>();
        }
    }
}
