using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class Fuel
    {
        public Fuel()
        {
            ProviderOfFuel = new HashSet<ProviderOfFuel>();
            Storage = new HashSet<Storage>();
        }

        public string FuelId { get; set; }
        public string FuelType { get; set; }

        public virtual ICollection<ProviderOfFuel> ProviderOfFuel { get; set; }
        public virtual ICollection<Storage> Storage { get; set; }
    }
}
