using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblFlight
    {
        public TblFlight()
        {
            TblSchedule = new HashSet<TblSchedule>();
        }
        public string FlightId { get; set; }
        public string AirlineId { get; set; }
        public string InstrumentUsed { get; set; }
        public int TotalSeats { get; set; }
        public int TotalBusinessSeats { get; set; }
        public int TotalNonBusinessSeats { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public HashSet<TblSchedule> TblSchedule { get; private set; }
        public virtual TblAirlines Airline { get; set; }
        public virtual ICollection<TblSchedule> SchedulesMaster { get; set; }
    }
}
