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
    [Route("api/{v:apiVersion}/flight/scheduleServices/[controller]")]
    [ApiController]
    public class ScheduleAPIController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public ScheduleAPIController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllSchedules()
        {
            try
            {
                var schedules = _repository.TblSchedules.GetAllSchedules();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }

        }

        [HttpGet]
        [Route("[Action]/{Id}")]
        public IActionResult GetScheduleById(long Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("Please provide valid schedule Id");
                }
                var schedule = _repository.TblSchedules.GetScheduleById(Id);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }

        }

        [Route("availableAirlines")]
        [HttpGet]
        public IActionResult GetScheduleByAirlineIDAndFlightID(string source, string destination, DateTime tripDate)
        {
            try
            {
                if (source == null || destination == null || tripDate == null)
                {
                    return BadRequest("Please provide valid input");
                }
                var schedules = _repository.TblSchedules.GetAvailableAirlines(source, destination, tripDate);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [HttpGet]
        [Route("searchSchedule/{airlineID}/{flightID}")]        
        public IActionResult GetScheduleByAirlineIDAndFlightID(long airlineID, long flightID)
        {
            try
            {
                if (airlineID <= 0 || flightID <= 0)
                {
                    return BadRequest("Please provide valid discount code");
                }
                var schedules = _repository.TblSchedules.GetAllSchedulesByFlightAndAirline(airlineID, flightID);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateSchedule([FromBody] ScheduleCreateDto schedule)
        {
            try
            {
                if (schedule == null)
                {
                    return BadRequest("Schedule object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var schduleEntity = _mapper.Map<TblSchedule>(schedule);

                schduleEntity.CreatedBy = schedule.UserID.ToString();
                schduleEntity.CreatedDate = DateTime.Now;
                schduleEntity.ModifiedDate = DateTime.Now;

                _repository.TblSchedules.CreateSchedule(schduleEntity);
                _repository.Save();

                return Ok(new { Message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult UpdateSchedule(int id, [FromBody] ScheduleCreateDto schedule)
        {
            try
            {
                if (schedule == null || id <= 0)
                {
                    return BadRequest("Schedule object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var scheduleEntity = _repository.TblSchedules.GetScheduleById(id);
                if (scheduleEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(schedule, scheduleEntity);

                scheduleEntity.ModifiedBy = schedule.UserID;
                scheduleEntity.ModifiedDate = DateTime.Now;               
                _repository.TblSchedules.Update(scheduleEntity);
                _repository.Save();

                return Ok(new { Message = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule(long id)
        {
            try
            {

                var scheduleEntity = _repository.TblSchedules.GetScheduleById(id);
                if (scheduleEntity == null)
                {
                    return NotFound();
                }
                _repository.TblSchedules.Delete(scheduleEntity);
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