using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblSchedule
    {
        public TblSchedule()
        {
            TblPassengers = new HashSet<TblPassenger>();
        }

        public long ScheduleId { get; set; }
        public long AirlineId { get; set; }
        public long FlightId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string ScheduledDays { get; set; }
        public decimal BusinessTicketPrice { get; set; }
        public decimal NonBusinessTicketPrice { get; set; }
        public string MealPreferences { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual TblAirline Airline { get; set; }
        public virtual TblFlight Flight { get; set; }
        public virtual ICollection<TblPassenger> TblPassengers { get; set; }
    }
}
