using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblBooking
    {
        public TblBooking()
        {
            TblPassengers = new HashSet<TblPassenger>();
        }

        public long Pnrid { get; set; }
        public long AirlineId { get; set; }
        public long FlightId { get; set; }
        public string TripType { get; set; }
        public DateTime TripDate { get; set; }
        public string ModeOfPayment { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual TblAirline Airline { get; set; }
        public virtual ICollection<TblPassenger> TblPassengers { get; set; }
    }
}
