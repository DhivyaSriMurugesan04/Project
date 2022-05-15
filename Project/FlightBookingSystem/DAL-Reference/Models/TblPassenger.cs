using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblPassenger
    {
        public long PassengerId { get; set; }
        public long Pnrid { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string SeatNo { get; set; }
        public string SeatType { get; set; }
        public long ScheduleId { get; set; }
        public long? DiscountId { get; set; }
        public string Status { get; set; }
        public string MealPreference { get; set; }
        public string Price { get; set; }
        public string TotalPrice { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual TblDiscount Discount { get; set; }
        public virtual TblBooking Pnr { get; set; }
        public virtual TblSchedule Schedule { get; set; }
    }
}
