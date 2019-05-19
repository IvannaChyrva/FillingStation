using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FillingStation.DTOs
{
    public class StorageDTO
    {
        public string StorageId { get; set; }
        public string FuelId { get; set; }
        public decimal StorageAmount { get; set; }
        public decimal? StoragePrice { get; set; }
    }
}
