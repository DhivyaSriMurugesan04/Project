using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Reference.Repository
{
    public class BookingRepo : RepositoryBase<TblBooking>, IBookingsRepository
    {
        FlightBookingApplicationDBContext _repository;

        public BookingRepo(FlightBookingApplicationDBContext repositoryContext):base (repositoryContext)
        {
            _repository = repositoryContext;
        }
        void CreateBooking(TblBooking booking)
        {
            Create(booking);
        }
        void UpdateBooking(TblBooking booking)
        {
            Update(booking);
        }
        void DeleteBooking(TblBooking booking)
        {
            Delete(booking);
        }

        IEnumerable<TblBooking> GetAllBookings()
        {
            return FindAll()
               .OrderBy(u => u.Pnrid)
               .ToList();
        }
        public TblBooking GetBookingById(string ID)
        {
            return FindByCondition(u => u.Pnrid == ID).FirstOrDefault();
        }
        IEnumerable<TblBooking> GetAllBookingsByUserId(string UserID)
        {
            return _repository.TblBookings.Where(u => u.CreatedBy == UserID)
            .Include(u => u.PassengerDetails)
            .Include(u => u.Airline)
            .OrderBy(o => o.Pnrid).ToList();
        }

        TblBooking GetBookingByIdWithPassenger(string ID)
        {
            return _repository.TblBookings.Where(u => u.Pnrid == ID)
                 .Include(u => u.PassengerDetails)
                 .OrderBy(o => o.Pnrid).FirstOrDefault();
        }
        IEnumerable<TblBooking> GetAllBookingsByPNRIdAndUserId(long Pnrid, long UserId)
        {
            return FindAll()
              .OrderBy(u => u.Pnrid)
              .ToList();
        }

        TblBooking GetAllBookingsByPNRIdAndUserIdAndTripDate(string Pnrid, string UserId, DateTime tripDate)
        {
            return _repository.TblBookings.Where(u => u.Pnrid == Pnrid && u.CreatedBy == UserId && u.CreatedOn < tripDate)//Need to change as trip date
                .Include(u => u.PassengerDetails)
                .OrderBy(o => o.Pnrid).FirstOrDefault();
        }
        
        IEnumerable<TblBooking> GetBookingHistoryAllByAirlineIdAndFlightId(string airlineId, string flightId, DateTime tripDate)
        {
            return _repository.TblBookings.Where(u => u.AirlineId == airlineId && u.FlightId == flightId && u.TripDate.Date == tripDate.Date)
           .Include(u => u.PassengerDetails)
           .Include(u => u.Airline)
           .OrderBy(o => o.Pnrid).ToList();
        }

        IEnumerable<TblBooking> GetBookingHistoryAllByUserId(string UserID)
        {
            return _repository.TblBookings.Where(u => u.CreatedBy == UserID)
            .Include(u => u.PassengerDetails)
            .Include(u => u.Airline)
            .OrderBy(o => o.Pnrid).ToList();
        }

        
    }
}
