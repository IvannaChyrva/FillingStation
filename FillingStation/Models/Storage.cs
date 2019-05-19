using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class Storage
    {
        public Storage()
        {
            Selling = new HashSet<Selling>();
        }

        public string StorageId { get; set; }
        public string FuelId { get; set; }
        public decimal StorageAmount { get; set; }
        public decimal? StoragePrice { get; set; }
        public DateTime? StorageDatetime { get; set; }
        public string StationId { get; set; }

        public virtual Fuel Fuel { get; set; }
        public virtual Station Station { get; set; }
        public virtual ICollection<Selling> Selling { get; set; }
    }
}
