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
        public void CreateBooking(TblBooking booking)
        {
            Create(booking);
        }
        public void UpdateBooking(TblBooking booking)
        {
            Update(booking);
        }
        public void DeleteBooking(TblBooking booking)
        {
            Delete(booking);
        }

        public IEnumerable<TblBooking> GetAllBookings()
        {
            return FindAll()
               .OrderBy(u => u.Pnrid)
               .ToList();
        }
        public TblBooking GetBookingById(long ID)
        {
            return FindByCondition(u => u.Pnrid == ID).FirstOrDefault();
        }
        public IEnumerable<TblBooking> GetAllBookingsByUserId(long UserID)
        {
            return _repository.TblBookings.Where(u => u.CreatedBy == UserID)
            .Include(u => u.TblPassengers)
            .Include(u => u.Airline)
            .OrderBy(o => o.Pnrid).ToList();
        }

        public TblBooking GetBookingByIdWithPassenger(long ID)
        {
            return _repository.TblBookings.Where(u => u.Pnrid == ID)
                 .Include(u => u.TblPassengers)
                 .OrderBy(o => o.Pnrid).FirstOrDefault();
        }
        public IEnumerable<TblBooking> GetAllBookingsByPNRIdAndUserId(long Pnrid, long UserId)
        {
            return FindAll()
              .OrderBy(u => u.Pnrid)
              .ToList();
        }

        public TblBooking GetAllBookingsByPNRIdAndUserIdAndTripDate(long Pnrid, long UserId, DateTime tripDate)
        {
            return _repository.TblBookings.Where(u => u.Pnrid == Pnrid && u.CreatedBy == UserId && u.CreatedOn < tripDate)//Need to change as trip date
                .Include(u => u.TblPassengers)
                .OrderBy(o => o.Pnrid).FirstOrDefault();
        }
        
        public IEnumerable<TblBooking> GetBookingHistoryAllByAirlineIdAndFlightId(long airlineId, long flightId, DateTime tripDate)
        {
            return _repository.TblBookings.Where(u => u.AirlineId == airlineId && u.FlightId == flightId && u.TripDate.Date == tripDate.Date)
           .Include(u => u.TblPassengers)
           .Include(u => u.Airline)
           .OrderBy(o => o.Pnrid).ToList();
        }

        public IEnumerable<TblBooking> GetBookingHistoryAllByUserId(long UserID)
        {
            return _repository.TblBookings.Where(u => u.CreatedBy == UserID)
            .Include(u => u.TblPassengers)
            .Include(u => u.Airline)
            .OrderBy(o => o.Pnrid).ToList();
        }

        
    }
}
