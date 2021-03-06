using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IScheduleRepository : IRepositoryBase<TblSchedule>
    {
        IEnumerable<TblSchedule> GetAllSchedules();
        IEnumerable<TblSchedule> GetAllSchedulesByFlightAndAirline(long AirlineID, long flightID);
        IEnumerable<TblSchedule> GetAvailableAirlines(string source, string destination, DateTime tripDate);
        TblSchedule GetScheduleById(long ID);
        void CreateSchedule(TblSchedule scheduleMaster);
        void UpdateSchedule(TblSchedule scheduleMaster);
        void DeleteSchedule(TblSchedule scheduleMaster);
    }
}
