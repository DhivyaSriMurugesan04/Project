using System;
using System.Collections.Generic;

//#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblAirlines

    {
        public TblAirlines()
        {
            TblBooking = new HashSet<TblBooking>();
            TblFlight = new HashSet<TblFlight>();
            TblSchedule = new HashSet<TblSchedule>();
        }

        public string AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public bool IsBlock { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AirlineLogo { get; set; }
        public virtual ICollection<TblBooking> Bookings { get; set; }
        public virtual ICollection<TblFlight> FlightsMaster { get; set; }
        public virtual ICollection<TblSchedule> SchedulesMaster { get; set; }
        public HashSet<TblBooking> TblBooking { get; private set; }
        public HashSet<TblFlight> TblFlight { get; private set; }
        public HashSet<TblSchedule> TblSchedule { get; private set; }
    }
    
}
