using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace DAL_Reference.Models.DTOs
{
    public class AirlineEditStatusDto
    {

        //[Required(ErrorMessage = "Airline Id is required")]
        //public long AirlineID { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "User Id is required")]
        public string UserID { get; set; }

    }
}
