using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FillingStation.DTOs;

namespace FillingStation.MapperProfiles
{
    public class StorageProfile : Profile 
    {
        public StorageProfile()
        {
            CreateMap<Storage, StorageDTO>();
            CreateMap<StorageDTO, Storage>();
        }
    }
}
