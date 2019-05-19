using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Selling = new HashSet<Selling>();
        }

        public string PaymentId { get; set; }
        public string PaymentType1 { get; set; }

        public virtual ICollection<Selling> Selling { get; set; }
    }
}
