using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblPassenger
    {
        public string PassengerId { get; set; }
        public string Pnrid { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string SeatNo { get; set; }
        public string SeatType { get; set; }
        public string ScheduleId { get; set; }
        public string DiscountId { get; set; }
        public string Status { get; set; }
        public string MealPreference { get; set; }
        public string Price { get; set; }
        public string TotalPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual TblDiscount Discount { get; set; }
        public virtual TblBooking Pnr { get; set; }
        public virtual TblSchedule Schedule { get; set; }
    }
}
