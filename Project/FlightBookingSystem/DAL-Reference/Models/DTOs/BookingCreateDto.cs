using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit.Sdk;

namespace DAL_Reference.Models.DTOs
{
    public class BookingCreateDto
    {
        [Required(ErrorMessage = "Flight ID is required")]
        public long FlightID { get; set; }
        [Required(ErrorMessage = "Airline ID is required")]
        public long AirlineID { get; set; }
        [Required(ErrorMessage = "Payment mode is required")]
        public string ModePayment { get; set; }
        [Required(ErrorMessage = "Trip type is required")]
        public string TripType { get; set; }
        [Required(ErrorMessage = "User ID is required")]
        public long UserID { get; set; }
        [Required(ErrorMessage = "Trip Date is required")]
        public DateTime TripDate { get; set; }
        [Required(ErrorMessage = "Passenger Detail is required")]
        public virtual ICollection<PassengerCreateDto> PassengerDetails { get; set; }
    }
}
