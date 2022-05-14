using AutoMapper;
using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using FlightBookingAPI.Models.Dtos;
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
    [AllowAnonymous]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/flight/Users/[controller]")]
    [ApiController]
    public class UsersAPIController : ControllerBase
    {
        FlightBookingApplicationDBContext _flightApplicationDBContext;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;       
        private readonly ILoggerManager _logger;

        public UsersAPIController(FlightBookingApplicationDBContext flightApplicationDBContext , IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _flightApplicationDBContext = flightApplicationDBContext;
            _repository = repository;
            _mapper = mapper;           
            _logger = logger;


        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repository.TblUser.GetAllUsers();
                var usersResult = _mapper.Map<IEnumerable<UserDto>>(users);

                return Ok(usersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal Server Error." + ex);
                return StatusCode(500, ex.Message); ;
            }

        }


        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] UserCreateDto user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var userEntity = _mapper.Map<TblUser>(user);
                userEntity.Status = "Active";
                userEntity.Role = "User";
                userEntity.CreatedDate = DateTime.Now;
                userEntity.ModifiedDate = DateTime.Now;
               _repository.TblUser.CreateUser(userEntity);
               _repository.Save();

                return Ok(new { Message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal Server Error." + ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]                
        public IActionResult UpdateUser(long id, [FromBody] UserCreateDto user)
        {
            try
            {
                if (user == null || id <= 0 )
                {
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var userEntity = _repository.TblUser.GetUserById(id);
                if (userEntity == null)
                {
                    return NotFound();
                }
                userEntity.FirstName = user.Name;                
                userEntity.PassWord = user.Password;
                userEntity.PhoneNumber = user.PhoneNo;               
                userEntity.ModifiedDate = DateTime.Now;
                _repository.TblUser.Update(userEntity);
                _repository.Save();

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal Server Error." + ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            try
            {

                var userEntity = _repository.TblUser.GetUserById(id);
                if (userEntity == null)
                {
                    return NotFound();
                }
                _repository.TblUser.Delete(userEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal Server Error." + ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
