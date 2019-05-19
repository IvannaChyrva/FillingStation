using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class Station
    {
        public Station()
        {
            Employee = new HashSet<Employee>();
            Storage = new HashSet<Storage>();
        }

        public string StationId { get; set; }
        public string StationName { get; set; }
        public string StationAddress { get; set; }
        public decimal StationPhone { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Storage> Storage { get; set; }
    }
}
