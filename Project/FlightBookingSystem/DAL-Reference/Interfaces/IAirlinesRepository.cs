using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IAirlinesRepository : IRepositoryBase<TblAirlines>
    {
        IEnumerable<TblAirlines> GetAllAirlnes();
        TblAirlines GetAirlineById(string airlineID);
        IEnumerable<TblAirlines> GetFlightsByAirlineId(string airlineID);

        void CreateAirline(TblAirlines airlinesMaster);
        void UpdateAirline(TblAirlines airlinesMaster);
        void DeleteAirline(TblAirlines airlinesMaster);
    }
}
