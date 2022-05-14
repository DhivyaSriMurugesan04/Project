using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Reference.Repository
{
    public class ScheduleRepo : RepositoryBase<TblSchedule>, IScheduleRepository
    {
        private FlightBookingApplicationDBContext _repositoryContext;

        public ScheduleRepo(FlightBookingApplicationDBContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IEnumerable<TblSchedule> GetAllSchedules()
        {
            return FindAll()
               .OrderBy(u => u.ScheduleId)
               .ToList();
        }

        public TblSchedule GetScheduleById(long ID)
        {
            return FindByCondition(u => u.ScheduleId == ID).FirstOrDefault();
        }
        public IEnumerable<TblSchedule> GetAllSchedulesByFlightAndAirline(long airlineID, long flightId)
        {
            return FindAll()
                .Where(u => u.AirlineId == airlineID && u.FlightId == flightId)
               .OrderBy(u => u.ScheduleId)
               .ToList();
        }

        public IEnumerable<TblSchedule> GetAvailableAirlines(string source, string destination, DateTime tripDate)
        {
            string scheduledDays = "";
            var inputDay = tripDate.DayOfWeek;
            if (inputDay == DayOfWeek.Saturday || inputDay == DayOfWeek.Sunday)
            {
                scheduledDays = "Weekends";
            }
            else
            {
                scheduledDays = "Weekdays";
            }
            
            return _repositoryContext.TblSchedules
                .Include(u => u.Airline)
                .Include(u => u.Flight)
                .Where(u => u.Source.ToLower().Equals(source.ToLower())
                && u.Destination.ToLower().Equals(destination.ToLower())
                && u.DepartureTime.Date >= tripDate.Date &&
                u.ScheduledDays.ToLower().Equals(scheduledDays.ToLower())
                && !u.Airline.IsBlock
                ).ToList();

        }

        public void CreateSchedule(TblSchedule schedulesMaster)
        {
            Create(schedulesMaster);
        }
        public void UpdateSchedule(TblSchedule schedulesMaster)
        {
            Update(schedulesMaster);
        }
        public void DeleteSchedule(TblSchedule schedulesMaster)
        {
            Delete(schedulesMaster);
        }


    }
}
