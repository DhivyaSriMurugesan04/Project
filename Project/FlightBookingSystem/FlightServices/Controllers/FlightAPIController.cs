using DAL_Reference.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    public class FlightAPIController : ControllerBase
    {

        FlightBookingApplicationDBContext _flightApplicationDBContext;
        public FlightAPIController(FlightBookingApplicationDBContext flightApplicationDBContext)
        {
            _flightApplicationDBContext = flightApplicationDBContext;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<TblFlight> GetFlightDetails()
        {
            return _flightApplicationDBContext.TblFlights.ToList();
        }


        [HttpPost]
        [Route("PostFlightDetails")]
        public IActionResult PostFlightDetails([FromBody] TblFlight tblFlightDetail)
        {

            _flightApplicationDBContext.TblFlights.Add(tblFlightDetail);
            _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }


        [HttpPut]
        [Route("PutFlightDetails")]
        public IActionResult PutFlightDetails([FromBody] TblFlight tblFlightDetail)
        {

            _flightApplicationDBContext.Entry(tblFlightDetail).State = EntityState.Modified;
            _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }


        [HttpDelete]
        [Route("DeleteFlightDetails")]
        public IActionResult DeleteFlightDetails(int FlightId)
        {

            var flightId = _flightApplicationDBContext.TblFlights.Find(FlightId);
            _flightApplicationDBContext.TblFlights.Remove(flightId);
            _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }
    }
}
