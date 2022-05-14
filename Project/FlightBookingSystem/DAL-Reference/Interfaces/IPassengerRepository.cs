using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IPassengerRepository : IRepositoryBase<TblPassenger>
    {
        IEnumerable<TblPassenger> GetAllPassengerDetails();
        IEnumerable<TblPassenger> GetAllPassengerByUserId(long UserID);
        IEnumerable<TblPassenger> GetAllPassengerByPNRID(long PNRID);
        IEnumerable<TblPassenger> GetAllPassengerByPNRIDAndUserID(long PNRID, long UserID);

        TblPassenger GetPassengerById(long ID);
        void CreatePassenger(TblPassenger passenger);
        void UpdatePassenger(TblPassenger passenger);
        void DeletePassenger(TblPassenger passenger);
    }
}
