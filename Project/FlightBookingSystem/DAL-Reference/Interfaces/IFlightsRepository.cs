using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IFlightsRepository : IRepositoryBase<TblFlight>
    {
        IEnumerable<TblFlight> GetAllFlights();
        IEnumerable<TblFlight> GetFlightByAirlineId(string AirlineID);
        TblFlight GetFlightById(string flightID);
        

        void CreateFlight(TblFlight flightsMaster);
        void UpdateFlight(TblFlight flightsMaster);
        void DeleteFlight(TblFlight flightsMaster);
    }
}
