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
    [Route("api/{v:apiVersion}/flight/[controller]")]
    [ApiController]
    public class BookingAPIController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public BookingAPIController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]        
        public IActionResult GetAllBookings()
        {
            try
            {
                var bookings = _repository.TblBooking.GetAllBookings();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [HttpGet("{Id}")]        
        public IActionResult GetBookingById(long Id)
        {
            try
            {
                if (Id <=0 )
                {
                    return BadRequest("Please provide valid PNR Id");
                }
                var booking = _repository.TblBooking.GetBookingById(Id);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [Route("history/{userId}")]
        [HttpGet]
        public IActionResult GetBookingByUserId(long userId)
        {
            try
            {
                if (userId<=0)
                {
                    return BadRequest("Please provide valid user Id");
                }
                var bookings = _repository.TblBooking.GetAllBookingsByUserId(userId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [Route("historyall/{userId}")]
        [HttpGet]
        public IActionResult GetBookingHistoryAllByUserId(long userId)
        {
            try
            {
                if (userId<=0)
                {
                    return BadRequest("Please provide valid user Id");
                }
                var bookings = _repository.TblBooking.GetBookingHistoryAllByUserId(userId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }
        }

        [Route("history/{PNRID}/{userID}")]
        [HttpGet]
        public IActionResult GetAllBookingsByPNRIdAndUserId(long PNRID, long userID)
        {
            try
            {
                if (PNRID <=0 || userID<=0)
                {
                    return BadRequest("Please provide valid input");
                }
                var bookings = _repository.TblBooking.GetAllBookingsByPNRIdAndUserId(PNRID, userID);
                // var result = JsonConvert.SerializeObject(bookings);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("historybyairline/{airlineId}/{flightId}/{tripDate}")]
        [HttpGet]
        public IActionResult GetAllBookingsByAirlineIdAndFlightId(long airlineId, long flightId, DateTime tripDate)
        {
            try
            {
                if (airlineId<=0 || flightId<=0 || tripDate == null)
                {
                    return BadRequest("Please provide valid input");
                }
                DateTime tripdateTime = Convert.ToDateTime(tripDate);
                var bookings = _repository.TblBooking.GetBookingHistoryAllByAirlineIdAndFlightId(airlineId, flightId, tripdateTime);
                // var result = JsonConvert.SerializeObject(bookings);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("cancel")]
        public IActionResult CancelBooking([FromBody] BookingCancelDto booking)
        {
            try
            {
                if (booking == null)
                {
                    return BadRequest("Booking object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                DateTime currentDate = DateTime.Now.AddHours(24);

                var bookings = _repository.TblBooking.GetAllBookingsByPNRIdAndUserIdAndTripDate(booking.PnrID, booking.UserID, currentDate);
                if (bookings != null)
                {
                    if (bookings.TblPassengers.Count() > 0)
                    {
                        var passengerDetails = bookings.TblPassengers.Where(p => p.PassengerId == booking.PassengerId).FirstOrDefault();
                        passengerDetails.Status = "Cancelled";
                        //foreach (PassengerDetails item in bookings.PassengerDetails)
                        //{
                        //    item.Status = "Cancelled";
                        //}
                        _repository.Save();
                    }
                }
                return Ok(new { Message = "Cancelled Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateBooking([FromBody] BookingCreateDto booking)
        {
            try
            {
                long? discounId=0;

                if (booking == null)
                {
                    return BadRequest("Booking object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var bookingEntity = _mapper.Map<TblBooking>(booking);

                bookingEntity.CreatedBy = booking.UserID;
                bookingEntity.CreatedOn = DateTime.Now;
                bookingEntity.ModifiedDate = DateTime.Now;

                foreach (var passenger in bookingEntity.TblPassengers)
                {
                    discounId = passenger.DiscountId;
                    if (passenger.DiscountId == 0)
                    {
                        passenger.DiscountId = null;
                    }
                    passenger.CreatedBy = booking.UserID;
                    passenger.CreatedDate = DateTime.Now;
                    passenger.ModifiedDate = DateTime.Now;
                    passenger.Status = "Booked";
                }
               
                var discountEntity = _repository.TblDiscounts.GetDiscountById((long)discounId);
                if (discountEntity != null)
                {
                    discountEntity.Status = "Applied";
                    discountEntity.ModifiedDate = DateTime.Now;
                    discountEntity.ModifiedBy = booking.UserID;
                    _repository.TblDiscounts.UpdateDiscount(discountEntity);
                }

                _repository.TblBooking.CreateBooking(bookingEntity);
                _repository.Save();


                return Ok(new { Message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]        
        public IActionResult UpdateBooking(long id, [FromBody] BookingCreateDto booking)
        {
            try
            {
                if (booking == null || id<=0 )
                {
                    return BadRequest("Booking object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var bookingEntity = _repository.TblBooking.GetBookingByIdWithPassenger(id);
                if (bookingEntity == null)
                {
                    return NotFound();
                }

                bookingEntity.AirlineId = booking.AirlineID;
                bookingEntity.FlightId = booking.FlightID;
                bookingEntity.TripType = booking.TripType;
                bookingEntity.ModeOfPayment = booking.ModePayment;
                bookingEntity.ModifiedDate = DateTime.Now;
                bookingEntity.ModifiedBy = booking.UserID;

                _repository.TblBooking.UpdateBooking(bookingEntity);
                _repository.Save();

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBooking(long id)
        {
            try
            {

                var bookingEntity = _repository.TblBooking.GetBookingById(id);
                if (bookingEntity == null)
                {
                    return NotFound();
                }
                _repository.TblBooking.Delete(bookingEntity);
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