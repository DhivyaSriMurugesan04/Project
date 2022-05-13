using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL_Reference.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FlightBookingApplicationDBContext _repositoryContext;
        private IUserRepository _userMaster;
        private IAirlinesRepository _airlinesMaster;
        private IFlightsRepository _flightsMaster;
        private IDiscountsRepository _discountsMaster;
        private IScheduleRepository _scheduleMaster;
        private IBookingsRepository _bookings;
        private IPassengerRepository _passengerDetails;
        public RepositoryWrapper(FlightBookingApplicationDBContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

        public IUserRepository TblUser
        {
            get
            {
                if (_userMaster == null)
                {
                    _userMaster = new UserRepo(_repositoryContext);
                }
                return _userMaster;
            }
        }

        public IAirlinesRepository TblAirline
        {
            get
            {
                if (_airlinesMaster == null)
                {
                    _airlinesMaster = new AirlinesRepo(_repositoryContext);
                }
                return _airlinesMaster;
            }
        }

        public IFlightsRepository TblFlights
        {
            get
            {
                if (_flightsMaster == null)
                {
                    _flightsMaster = new FlightsRepo(_repositoryContext);
                }
                return _flightsMaster;
            }
        }
        public IDiscountsRepository TblDiscounts
        {     
            get
            {
                if (_discountsMaster == null)
                {
                    _discountsMaster = new DiscountsRepo(_repositoryContext);
                }
                return _discountsMaster;
            }
        }

        public IScheduleRepository TblSchedules
        {
            get
            {
                if (_scheduleMaster == null)
                {
                    _scheduleMaster = new ScheduleRepo(_repositoryContext);
                }
                return _scheduleMaster;
            }
        }

        public IBookingsRepository TblBooking
        {
            get
            {
                if (_bookings == null)
                {
                    _bookings = new BookingRepo(_repositoryContext);
                }
                return _bookings;
            }
        }

        public IPassengerRepository TblPassengers
        {
            get
            {
                if (_passengerDetails == null)
                {
                    _passengerDetails = new PassengerInfoRepo(_repositoryContext);
                }
                return _passengerDetails;
            }
        }

    }
}
