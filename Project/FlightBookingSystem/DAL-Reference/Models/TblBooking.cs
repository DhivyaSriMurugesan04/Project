using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Reference.Models
{
    public class TblBooking
    {
        public TblBooking()
        {
            TblPassenger = new HashSet<TblPassenger>();
        }
        public string Pnrid { get; set; }
        public string AirlineId { get; set; }
        public string FlightId { get; set; }
        public string TripType { get; set; }
        public DateTime TripDate { get; set; }
        public string ModeOfPayment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public HashSet<TblPassenger> TblPassenger { get; private set; }
        public virtual TblAirlines Airline { get; set; }
        public virtual ICollection<TblPassenger> PassengerDetails { get; set; }
    }
}
