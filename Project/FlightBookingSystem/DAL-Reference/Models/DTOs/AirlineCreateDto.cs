using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models.DTOs
{
    public class AirlineCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string AirlineName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }

        public long? UserID { get; set; }
    }
}