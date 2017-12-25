using System;
using System.Collections.Generic;
using System.Text;
using Amlak.Core.Entities;
using Amlak.Core.ViewModel;
using Amlak.Core.ViewModel.House;
using AutoMapper;

namespace Amlak.Core.SSOT
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<House, HouseViewModel>();
            CreateMap<HouseViewModel, House>();

            CreateMap<CreateHouseViewModel,House>();

        }
    }
}
