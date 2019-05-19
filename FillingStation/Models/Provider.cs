using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class Provider
    {
        public Provider()
        {
            ProviderOfFuel = new HashSet<ProviderOfFuel>();
        }

        public string ProviderId { get; set; }
        public string ProviderName { get; set; }
        public decimal ProviderPhone { get; set; }
        public string ProviderAddress { get; set; }

        public virtual ICollection<ProviderOfFuel> ProviderOfFuel { get; set; }
    }
}
