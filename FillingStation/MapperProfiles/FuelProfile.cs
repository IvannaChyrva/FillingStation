using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FillingStation.DTOs;

namespace FillingStation.MapperProfiles
{
    public class FuelProfile : Profile
    {
        public FuelProfile()
        {
            CreateMap<Fuel, FuelDTO>();
            CreateMap<FuelDTO, Fuel>();
        }
    }
}
