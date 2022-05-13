using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IPassengerRepository : IRepositoryBase<TblPassenger>
    {
        IEnumerable<TblPassenger> GetAllPassengerDetails();
        IEnumerable<TblPassenger> GetAllPassengerByUserId(string UserID);
        IEnumerable<TblPassenger> GetAllPassengerByPNRID(string PNRID);
        IEnumerable<TblPassenger> GetAllPassengerByPNRIDAndUserID(string PNRID, string UserID);

        TblPassenger GetPassengerById(string ID);
        void CreatePassenger(TblPassenger passenger);
        void UpdatePassenger(TblPassenger passenger);
        void DeletePassenger(TblPassenger passenger);
    }
}
