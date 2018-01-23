using System;
using System.Collections.Generic;
using System.Text;
using Amlak.Core.DTO.House;
using Amlak.Core.Entities;
using Amlak.Core.ViewModel;
using Amlak.Core.ViewModel.House;
using Amlak.Core.ViewModel.News;
using AutoMapper;

namespace Amlak.Core.SSOT
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<House, HouseViewModel>();
            CreateMap<HouseViewModel, House>();

            CreateMap<HouseCreateViewModel,House>();
            CreateMap<HouseEditViewModel, House>();
            CreateMap<House,HouseEditViewModel>();


            CreateMap<House, HouseFullDTO>();
            CreateMap<HouseFullDTO,House>();


            CreateMap<News,NewsViewModel>();
            CreateMap<NewsViewModel, News>();
        }
    }
}
