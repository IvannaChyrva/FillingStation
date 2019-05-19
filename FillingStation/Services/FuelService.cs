using AutoMapper;
using FillingStation.DTOs;
using FillingStation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FillingStation.Services
{
    public class FuelService : IFuelService
    {
        private readonly IMapper _mapper;
        private GenericRepository<Fuel> _fuelRepo;

        public FuelService(IMapper mapper, StationsDBContext context)
        {
            _mapper = mapper;
            _fuelRepo = new GenericRepository<Fuel>(context);
        }

        public async Task<IEnumerable<FuelDTO>> GetFuel()
        {
            var fuel = await _fuelRepo.GetAsync();
            var dto = _mapper.Map<IEnumerable<FuelDTO>>(fuel);
            return dto;
        }
    }
}
