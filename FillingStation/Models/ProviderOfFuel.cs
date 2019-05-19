using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class ProviderOfFuel
    {
        public string FuelId { get; set; }
        public string ProviderId { get; set; }
        public decimal? Price { get; set; }

        public virtual Fuel Fuel { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
