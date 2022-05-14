using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Reference.Repository
{
    public class AirlinesRepo : RepositoryBase<TblAirline>, IAirlinesRepository
    {
        private FlightBookingApplicationDBContext _repositoryContext;

        public AirlinesRepo(FlightBookingApplicationDBContext repositoryContext)
            : base(repositoryContext) => _repositoryContext = repositoryContext;
        public IEnumerable<TblAirline> GetAllAirlnes()
        {
            return FindAll()
               .OrderBy(u => u.AirlineId)
               .ToList();
        }

        public TblAirline GetAirlineById(long airlineID)
        {
            return FindByCondition(u => u.AirlineId == airlineID).FirstOrDefault();
        }
        

        public IEnumerable<TblAirline> GetFlightsByAirlineId(long airlineID)
        {
            return _repositoryContext.TblAirlines.Include(o => o.TblFlights).Where(o => o.AirlineId == airlineID).ToList();
            
        }
        
        public void CreateAirline(TblAirline airlinesMaster)
        {
            Create(airlinesMaster);
        }

        public void UpdateAirline(TblAirline airlinesMaster)
        {
            Update(airlinesMaster);
        }

        public void DeleteAirline(TblAirline airlinesMaster)
        {
            Delete(airlinesMaster);
        }
    }
}
