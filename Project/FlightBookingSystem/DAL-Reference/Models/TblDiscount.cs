using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblDiscount
    {
        public TblDiscount()
        {
            TblPassenger = new HashSet<TblPassenger>();
        }
        public string DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime AppliedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public HashSet<TblPassenger> TblPassenger { get; private set; }
        public virtual ICollection<TblPassenger> PassengerDetails { get; set; }
    }
}
