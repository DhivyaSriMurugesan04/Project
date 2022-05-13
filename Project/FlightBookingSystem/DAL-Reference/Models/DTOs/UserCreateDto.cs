using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models.Dtos
{
    public class UserCreateDto
    {
        //public int? UserId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNo { get; set; }
    }
}