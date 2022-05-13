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
        TblBooking GetBookingById(string ID);
        IEnumerable<TblBooking> GetAllBookingsByUserId(string UserID);
        TblBooking GetBookingByIdWithPassenger(string ID);
        IEnumerable<TblBooking> GetBookingHistoryAllByUserId(string UserID);
        IEnumerable<TblBooking> GetAllBookingsByPNRIdAndUserId(long Pnrid, long UserId);        
        TblBooking GetAllBookingsByPNRIdAndUserIdAndTripDate(string Pnrid, string UserId, DateTime tripDate);
        IEnumerable<TblBooking> GetBookingHistoryAllByAirlineIdAndFlightId(string airlineId, string flightId, DateTime tripDate);
    }
}
