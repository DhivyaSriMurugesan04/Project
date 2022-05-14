using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_Reference.Models.DTOs
{
    public class DiscountCreateDto
    {
        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Expiry Date is required")]
        public DateTime ExpiryDate { get; set; }
        public int UserID { get; set; }
    }
}
