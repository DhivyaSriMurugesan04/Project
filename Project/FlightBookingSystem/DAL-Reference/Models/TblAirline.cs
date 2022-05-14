using System;
using System.Collections.Generic;

//#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblAirline
    {
        public TblAirline()
        {
            TblBookings = new HashSet<TblBooking>();
            TblFlights = new HashSet<TblFlight>();
            TblSchedules = new HashSet<TblSchedule>();
        }

        public long AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public bool IsBlock { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AirlineLogo { get; set; }

        public virtual ICollection<TblBooking> TblBookings { get; set; }
        public virtual ICollection<TblFlight> TblFlights { get; set; }
        public virtual ICollection<TblSchedule> TblSchedules { get; set; }
    }
}
