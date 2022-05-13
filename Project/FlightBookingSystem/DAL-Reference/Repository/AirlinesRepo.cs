using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Reference.Repository
{
    public class AirlinesRepo : RepositoryBase<TblAirlines>, IAirlinesRepository
    {
        private FlightBookingApplicationDBContext _repositoryContext;

        public AirlinesRepo(FlightBookingApplicationDBContext repositoryContext)
            : base(repositoryContext) => _repositoryContext = repositoryContext;
        public IEnumerable<TblAirlines> GetAllAirlnes()
        {
            return FindAll()
               .OrderBy(u => u.AirlineId)
               .ToList();
        }

        public TblAirlines GetAirlineById(string airlineID)
        {
            return FindByCondition(u => u.AirlineId == airlineID).FirstOrDefault();
        }
        

        public IEnumerable<TblAirlines> GetFlightsByAirlineId(string airlineID)
        {
            return _repositoryContext.TblAirlines.Include(o => o.TblFlight).Where(o => o.AirlineId == airlineID).ToList();
            
        }
        
        public void CreateAirline(TblAirlines airlinesMaster)
        {
            Create(airlinesMaster);
        }

        public void UpdateAirline(TblAirlines airlinesMaster)
        {
            Update(airlinesMaster);
        }

        public void DeleteAirline(TblAirlines airlinesMaster)
        {
            Delete(airlinesMaster);
        }
    }
}
