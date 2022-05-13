using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_Reference.Models.DTOs
{
    public class ScheduleCreateDto
    {
        [Required(ErrorMessage = "Flight ID is required")]
        public long FlightID { get; set; }
        [Required(ErrorMessage = "Airline ID is required")]
        public long AirlineID { get; set; }
        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; }
        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "Departure Time is required")]
        public DateTime DepartureTime { get; set; }
        [Required(ErrorMessage = "Arival Time is required")]
        public DateTime ArrivalTime { get; set; }
        [Required(ErrorMessage = "Scheduled Days is required")]
        public string ScheduledDays { get; set; }
        [Required(ErrorMessage = "Business Ticket Price is required")]
        public decimal BusinessTicketPrice { get; set; }
        [Required(ErrorMessage = "Non Business Ticket Price is required")]
        public decimal NonBusinessTicketPrice { get; set; }
        [Required(ErrorMessage = "Meal Preferences is required")]
        public string MealPreferences { get; set; }
        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }
    }
}