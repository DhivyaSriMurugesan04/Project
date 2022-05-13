using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Reference.Repository
{
    public class FlightsRepository : RepositoryBase<TblFlight>, IFlightsRepository
    {
        FlightBookingApplicationDBContext _repository;

        public FlightsRepository(FlightBookingApplicationDBContext repositoryContext)
            : base(repositoryContext)
        {
            _repository = repositoryContext;
        }
        public IEnumerable<TblFlight> GetAllFlights()
        {
           return _repository.TblFlights.Where(u => u.AirlineId > 0)
            .Include(u => u.Airline)
            .OrderBy(o => o.FlightId).ToList();
        }

        public TblFlight GetFlightById(string FlightId)
        {
            return FindByCondition(u => u.FlightId == FlightId).FirstOrDefault();
        }

        public IEnumerable<TblFlight> GetFlightByAirlineId(string AirlineId)
        {
            return FindAll().Where(f => f.AirlineId == AirlineId).ToList();
        }

        public void CreateFlight(TblFlight flightsMaster)
        {
            Create(flightsMaster);
        }
        public void UpdateFlight(TblFlight flightsMaster)
        {
            Update(flightsMaster);
        }
        public void DeleteFlight(TblFlight flightsMaster)
        {
            Delete(flightsMaster);
        }


    }
}
