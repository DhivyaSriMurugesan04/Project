using AutoMapper;
using DAL_Reference.Models;
using DAL_Reference.Models.DTOs;
using FlightBookingAPI.Models.Dtos;
using FlightBookingAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TblUser, UserDto>();
            CreateMap<UserCreateDto, TblUser>();
            CreateMap<AirlineCreateDto, TblAirlines>();
            CreateMap<FlightCreateDto, TblFlight>();
            CreateMap<DiscountCreateDto, TblDiscount>();
            CreateMap<ScheduleCreateDto, TblSchedule>();
            CreateMap<BookingCreateDto, TblBooking>();
            CreateMap<PassengerCreateDto, TblPassenger>();

        }
    }
}
