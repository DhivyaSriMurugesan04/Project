using AutoMapper;
using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using FlightBookingAPI.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminServices.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;
        private readonly FlightBookingApplicationDBContext _dbContext;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;        
        private readonly ILoggerManager _logger;
             

        public LoginController(IJWTManagerRepository jWTManager, FlightBookingApplicationDBContext dbContext , IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            iJWTManager = jWTManager;
            _dbContext = dbContext;
            _repository = repository;
            _mapper = mapper;            
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] UserCredentials user)
        {
            try
            {
                var userEntity = _repository.TblUser.GetUserByEmailAndPwd(user.Email, user.Password);
                if (userEntity == null)
                {
                    return NotFound();
                }
                var token = iJWTManager.Authentication(user.Email, user.Password);
                if (token == null)
                    return Unauthorized();
                var userDetail = _mapper.Map<UserDto>(userEntity);

                var result = JsonConvert.SerializeObject(new { token, userDetail });
               // _logger.LogDebug("Login Success.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal Server Error." + ex);
                return StatusCode(500, ex.Message);
            }
        }
    }

        
}
