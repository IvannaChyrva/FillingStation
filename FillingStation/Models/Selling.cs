using System;
using System.Collections.Generic;

namespace FillingStation
{
    public partial class Selling
    {
        public string SellingId { get; set; }
        public string StorageId { get; set; }
        public decimal SellingAmount { get; set; }
        public decimal SellingTotal { get; set; }
        public decimal? Bonus { get; set; }
        public DateTime? SellingDate { get; set; }
        public string PaymentId { get; set; }
        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PaymentType Payment { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
