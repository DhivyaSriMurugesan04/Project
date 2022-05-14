using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_Reference.Models.DTOs
{
    public class FlightCreateDto
    {
        [Required(ErrorMessage = "Airline Id is required")]
        public long AirlineID { get; set; }

        [Required(ErrorMessage = "Total Seats is required")]
        public int TotalSeats { get; set; }

        [Required(ErrorMessage = "Total Business Seats is required")]
        public int TotalBusinessSeats { get; set; }

        [Required(ErrorMessage = "Total Non Business Seats is required")]
        public int TotalNonBusinessSeats { get; set; }

        [Required(ErrorMessage = "Instrument Used is required")]
        public string InstrumentUsed { get; set; }
        public long UserID { get; set; }

    }
}
