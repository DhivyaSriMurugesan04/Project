using System;
using System.Collections.Generic;
using System.Text;


namespace DAL_Reference.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository TblUser { get; }
        IAirlinesRepository TblAirline { get; }
        IFlightsRepository TblFlights { get; }
        IDiscountsRepository TblDiscounts { get; }
        IScheduleRepository TblSchedules { get; }
        IBookingsRepository TblBooking { get; }
        IPassengerRepository TblPassengers { get; }
        void Save();
    }
}
