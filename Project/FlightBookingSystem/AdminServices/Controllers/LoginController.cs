using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminServices.Controllers
{
    [Authorize]
    [Route("api/v1.0/flight/admin/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;
        private readonly FlightBookingApplicationDBContext _dbContext;
        public LoginController(IJWTManagerRepository jWTManager, FlightBookingApplicationDBContext dbContext)
        {
            iJWTManager = jWTManager;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(TblUser user)
        {
            IEnumerable<TblUser> tblusr = _dbContext.TblUsers.Where(x => x.UserId == user.UserId && x.PassWord == user.PassWord);
            if (tblusr.ToList().Count == 0)
            {
                return Unauthorized();
            }
            return new OkObjectResult(tblusr);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(string email, string password)
        {
            IEnumerable<TblUser> tblusr = _dbContext.TblUsers.Where(x => x.EmailId == email && x.PassWord == password);
            if (tblusr.ToList().Count == 0)
            {
                return Unauthorized();
            }
            var token = iJWTManager.Authentication(email, password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
