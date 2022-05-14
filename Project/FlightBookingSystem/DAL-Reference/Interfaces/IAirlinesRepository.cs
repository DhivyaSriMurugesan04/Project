using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IAirlinesRepository : IRepositoryBase<TblAirline>
    {
        IEnumerable<TblAirline> GetAllAirlnes();
        TblAirline GetAirlineById(long airlineID);
        IEnumerable<TblAirline> GetFlightsByAirlineId(long airlineID);

        void CreateAirline(TblAirline airlinesMaster);
        void UpdateAirline(TblAirline airlinesMaster);
        void DeleteAirline(TblAirline airlinesMaster);
    }
}
