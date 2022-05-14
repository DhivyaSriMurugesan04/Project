using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IBookingsRepository : IRepositoryBase<TblBooking>
    {
       
        void CreateBooking(TblBooking booking);
        void UpdateBooking(TblBooking booking);
        void DeleteBooking(TblBooking booking);
        IEnumerable<TblBooking> GetAllBookings();
        TblBooking GetBookingById(long ID);
        IEnumerable<TblBooking> GetAllBookingsByUserId(long UserID);
        TblBooking GetBookingByIdWithPassenger(long ID);
        IEnumerable<TblBooking> GetBookingHistoryAllByUserId(long UserID);
        IEnumerable<TblBooking> GetAllBookingsByPNRIdAndUserId(long Pnrid, long UserId);        
        TblBooking GetAllBookingsByPNRIdAndUserIdAndTripDate(long Pnrid, long UserId, DateTime tripDate);
        IEnumerable<TblBooking> GetBookingHistoryAllByAirlineIdAndFlightId(long airlineId, long flightId, DateTime tripDate);
    }
}
