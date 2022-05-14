using AutoMapper;
using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using DAL_Reference.Models.DTOs;
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
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/flight/PassengerServices/[controller]")]
    [ApiController]
    public class PassengerAPIController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public PassengerAPIController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllPassengerDetails()
        {
            try
            {
                var passengerDetails = _repository.TblPassengers.GetAllPassengerDetails();
                return Ok(passengerDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [HttpGet("{Id}")]        
        public IActionResult GetPassengerById(long Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("Please provide valid Id");
                }
                var passengerDetail = _repository.TblPassengers.GetPassengerById(Id);
                return Ok(passengerDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [Route("history/{PNRID}/{userID}")]
        [HttpGet]
        public IActionResult GetAllPassengerHistory(long PNRID, long userID)
        {
            try
            {
                if (PNRID <= 0 || userID <= 0)
                {
                    return BadRequest("Please provide valid input");
                }
                var passengerDetails = _repository.TblPassengers.GetAllPassengerByPNRIDAndUserID(PNRID, userID);
                return Ok(passengerDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreatePassenger([FromBody] PassengerCreateDto passenger)
        {
            try
            {
                if (passenger == null)
                {
                    return BadRequest("Passenger object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var passengerEntity = _mapper.Map<TblPassenger>(passenger);

                passengerEntity.CreatedBy = passenger.UserID;
                passengerEntity.CreatedDate = DateTime.Now;
                passengerEntity.ModifiedDate = DateTime.Now;

                _repository.TblPassengers.CreatePassenger(passengerEntity);
                _repository.Save();

                return Ok("Created Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePassenger(int id, [FromBody] PassengerCreateDto passenger)
        {
            try
            {
                if (passenger == null || id <= 0)
                {
                    return BadRequest("Passenger object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var passengerEntity = _repository.TblPassengers.GetPassengerById(id);
                if (passengerEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(passenger, passengerEntity);


                passengerEntity.ModifiedDate = DateTime.Now;
                passengerEntity.ModifiedBy = passenger.UserID;
                _repository.TblPassengers.Update(passengerEntity);
                _repository.Save();

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePassenger(long id)
        {
            try
            {

                var passengerEntity = _repository.TblPassengers.GetPassengerById(id);
                if (passengerEntity == null)
                {
                    return NotFound();
                }
                _repository.TblPassengers.Delete(passengerEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
