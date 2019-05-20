using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class Customer
    {
        public Customer()
        {
            Selling = new HashSet<Selling>();
        }

        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public decimal? Bonuses { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Selling> Selling { get; set; }
    }
}
