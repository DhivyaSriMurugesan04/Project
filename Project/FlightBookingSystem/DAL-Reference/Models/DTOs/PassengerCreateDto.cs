using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit.Sdk;

namespace DAL_Reference.Models.DTOs
{
    public class PassengerCreateDto
    {
      
        public long Pnrid { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email Id is required")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Seat No is required")]
        public string SeatNo { get; set; }
        [Required(ErrorMessage = "Schedule ID is required")]
        public long ScheduleID { get; set; }
        [Required(ErrorMessage = "Discount ID is required")]
        public long DiscountID { get; set; }
        //  [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Seat type is required")]
        public string SeatType { get; set; }
        [Required(ErrorMessage = "Meal Preference is required")]
        public string MealPreference { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Total Price is required")]
        public decimal TotalPrice { get; set; }
        
        public int UserID { get; set; }
    }
}
