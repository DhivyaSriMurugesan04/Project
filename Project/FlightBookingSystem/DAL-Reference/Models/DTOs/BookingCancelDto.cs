using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_Reference.Models.DTOs
{
    public class BookingCancelDto
    {
        [Required(ErrorMessage = "PNR ID is required")]
        public string PnrID { get; set; }
        [Required(ErrorMessage = "Passenger ID is required")]
        public string PassengerId { get; set; }
        [Required(ErrorMessage = "User ID is required")]
        public string UserID { get; set; }
    }
}
