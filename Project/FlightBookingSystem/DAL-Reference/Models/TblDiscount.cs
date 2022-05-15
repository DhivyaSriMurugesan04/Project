using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblDiscount
    {
        public TblDiscount()
        {
            TblPassengers = new HashSet<TblPassenger>();
        }

        public long DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime AppliedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TblPassenger> TblPassengers { get; set; }
    }
}
