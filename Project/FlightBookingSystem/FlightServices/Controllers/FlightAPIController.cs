using AutoMapper;
using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using DAL_Reference.Models.DTOs;
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
    [Route("api/{v:apiVersion}/flight/flightServices/[controller]")]
    [ApiController]
    public class FlightAPIController : ControllerBase
    {

        FlightBookingApplicationDBContext _flightApplicationDBContext;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public FlightAPIController(FlightBookingApplicationDBContext flightApplicationDBContext, IRepositoryWrapper repository, IMapper mapper)
        {
            _flightApplicationDBContext = flightApplicationDBContext;
            _repository = repository;
            _mapper = mapper;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllFlights()
        {
            try
            {
                var Flights = _repository.TblFlights.GetAllFlights();
                return Ok(Flights);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }

        }

        [Route("byAirlineId/{id}")]
        [HttpGet]
        public IActionResult GetFlightsByAirlineId(long id)
        {
            try
            {
                var Flights = _repository.TblFlights.GetFlightByAirlineId(id);
                return Ok(Flights);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }

        }


        [HttpPost]
        [Route("create")]
        public IActionResult CreateFlight([FromBody] FlightCreateDto flight)
        {
            try
            {
                if (flight == null)
                {
                    return BadRequest("Flight object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var flightEntity = _mapper.Map<TblFlight>(flight);
                flightEntity.CreatedBy = flight.UserID;
                flightEntity.CreatedDate = DateTime.Now;
                flightEntity.ModifiedDate = DateTime.Now;
                _repository.TblFlights.CreateFlight(flightEntity);
                _repository.Save();

                return Ok(new { Message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult UpdateFlight(long id, [FromBody] FlightCreateDto flight)
        {
            try
            {
                if (flight == null || id<=0)
                {
                    return BadRequest("Flight object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var flightEntity = _repository.TblFlights.GetFlightById(id);
                if (flightEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(flight, flightEntity);


                flightEntity.ModifiedDate = DateTime.Now;
                flightEntity.ModifiedBy = flight.UserID;
                _repository.TblFlights.Update(flightEntity);
                _repository.Save();

                return Ok(new { Message = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFlight(long id)
        {
            try
            {

                var flightEntity = _repository.TblFlights.GetFlightById(id);
                if (flightEntity == null)
                {
                    return NotFound();
                }
                _repository.TblFlights.Delete(flightEntity);
                _repository.Save();

                return Ok(new { Message = "Deleted Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
