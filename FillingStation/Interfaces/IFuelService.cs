using FillingStation.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FillingStation.Interfaces
{
    public interface IFuelService
    {
        Task<IEnumerable<FuelDTO>> GetFuel();
    }
}
