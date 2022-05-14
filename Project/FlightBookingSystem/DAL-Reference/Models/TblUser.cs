using System;
using System.Collections.Generic;

//#nullable disable

namespace DAL_Reference.Models
{
    public partial class TblUser
    {
        public long UserId { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedBy { get; set; }
    }
}
