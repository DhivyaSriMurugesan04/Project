using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblFlight
    {
        public TblFlight()
        {
            TblSchedules = new HashSet<TblSchedule>();
        }

        public long FlightId { get; set; }
        public long AirlineId { get; set; }
        public string InstrumentUsed { get; set; }
        public int TotalSeats { get; set; }
        public int TotalBusinessSeats { get; set; }
        public int TotalNonBusinessSeats { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedBy { get; set; }

        public virtual TblAirline Airline { get; set; }
        public virtual ICollection<TblSchedule> TblSchedules { get; set; }
    }
}
