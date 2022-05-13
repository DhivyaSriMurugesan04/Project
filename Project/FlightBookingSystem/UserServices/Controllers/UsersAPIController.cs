using DAL_Reference.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UserServices.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class UsersAPIController : ControllerBase
    {
        FlightBookingApplicationDBContext _flightApplicationDBContext;
        public UsersAPIController(FlightBookingApplicationDBContext flightApplicationDBContext)
        {
            _flightApplicationDBContext = flightApplicationDBContext;

            
        }

        [HttpGet]
        [Route("GetUserDetails")]
        public IEnumerable<TblUser> GetUserDetails()
        {
            return _flightApplicationDBContext.TblUsers.ToList();
        }

        //[HttpGet]
        //[Route("GetUserByIDDetails/{UserID}")]
        //public IEnumerable<TblUserDataDetail> GetUserDetails([FromBody] string UserID)
        //{
        //    return _flightApplicationDBContext.TblUserDataDetails.ToList();
        //}


        [HttpPost]
        [Route("PostUserDetails")]
        public IActionResult PostUserDetails([FromBody] TblUser tblUserDetail)
        {

            _flightApplicationDBContext.TblUsers.Add(tblUserDetail);
            _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }


        [HttpPut]
        [Route("PutUserDetails")]
        public IActionResult PutUserDetails([FromBody] TblUser tblUserDetail)
        {

            _flightApplicationDBContext.Entry(tblUserDetail).State = EntityState.Modified;
            _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }


        [HttpDelete]
        [Route("DeleteUserDetails")]
        public IActionResult DeleteUserDetails(int UserId)
        {

            var userId = _flightApplicationDBContext.TblUsers.Find(UserId);
            _flightApplicationDBContext.TblUsers.Remove(userId);
            _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }


    }
}
