using AutoMapper;
using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using DAL_Reference.Models.DTOs;
using FlightBookingAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class AirlineAPIController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public AirlineAPIController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllAirlines()
        {
            try
            {
                var airlines = _repository.TblAirline.GetAllAirlnes();
                // var airlinesResult = _mapper.Map<IEnumerable<UserDto>>(airlines);
                return Ok(airlines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }

        }

        [HttpGet]
        [Route("byAirlineId/{Id}")]
        public IActionResult GetFlightsByAirlineId(string Id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    return BadRequest("Please provide valid Airline Id");
                }
                var airlines = _repository.TblAirline.GetFlightsByAirlineId(Id);
                return Ok(airlines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }


        [HttpPost]
        [Route("create")]
        public IActionResult CreateAirline([FromBody] AirlineCreateDto airline)
        {
            try
            {
                if (airline == null)
                {
                    return BadRequest("Airline object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var airlineEntity = _mapper.Map<TblAirlines>(airline);

                airlineEntity.CreatedOn = DateTime.Now;
                airlineEntity.ModifiedDate = DateTime.Now;
               _repository.TblAirline.CreateAirline(airlineEntity);
               _repository.Save();

                return Ok(new { Message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("blockorunblock/{id}")]
        public IActionResult BlockOrUnblockAirline(string id, [FromBody] AirlineEditStatusDto airline)
        {
            try
            {
                if (airline == null || string.IsNullOrWhiteSpace(id))
                {
                    return BadRequest("Airline object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var airlineEntity = _repository.TblAirline.GetAirlineById(id);

                if (airlineEntity == null)
                {
                    return NotFound();
                }
                if (airline.Status.ToLower().Equals("active"))
                {
                    airlineEntity.IsBlock = true;
                }
                else
                {
                    airlineEntity.IsBlock = false;
                }
                airlineEntity.ModifiedBy = airline.UserID;
                airlineEntity.ModifiedDate = DateTime.Now;
                _repository.TblAirline.UpdateAirline(airlineEntity);
                _repository.Save();
                return Ok(new { Message = "Updated Successfully" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult UpdateAirline(string id, [FromBody] AirlineCreateDto airline)
        {
            try
            {
                if (airline == null || string.IsNullOrWhiteSpace(id))
                {
                    return BadRequest("Airline object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var airlineEntity = _repository.TblAirline.GetAirlineById(id);
                if (airlineEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(airline, airlineEntity);


                airlineEntity.ModifiedDate = DateTime.Now;
                airlineEntity.ModifiedBy = airline.UserID;
                _repository.TblAirline.Update(airlineEntity);
                _repository.Save();

                return Ok(new { Message = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAirline(string id)
        {
            try
            {

                var airlineEntity = _repository.TblAirline.GetAirlineById(id);
                if (airlineEntity == null)
                {
                    return NotFound();
                }
                _repository.TblAirline.Delete(airlineEntity);
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
