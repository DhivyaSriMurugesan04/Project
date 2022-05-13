using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Reference.Repository
{
    public class PassengerInfoRepo : RepositoryBase<TblPassenger>, IPassengerRepository
    {
        public PassengerInfoRepo(FlightBookingApplicationDBContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public IEnumerable<TblPassenger> GetAllPassengerDetails()
        {
            return FindAll()
               .OrderBy(u => u.PassengerId)
               .ToList();
        }

        public TblPassenger GetPassengerById(string ID)
        {
            return FindByCondition(u => u.PassengerId == ID).FirstOrDefault();
        }

        public IEnumerable<TblPassenger> GetAllPassengerByUserId(string userID)
        {
            return FindAll()
                .Where(u => u.CreatedBy == userID)
               .OrderBy(u => u.Pnrid)
               .ToList();
        }
        public IEnumerable<TblPassenger> GetAllPassengerByPNRID(string Pnrid)
        {
            return FindAll()
                .Where(u => u.Pnrid == Pnrid)
               .OrderBy(u => u.Pnrid)
               .ToList();
        }
        public IEnumerable<TblPassenger> GetAllPassengerByPNRIDAndUserID(string Pnrid, string userID)
        {
            return FindAll()
                .Where(u => u.Pnrid == Pnrid && u.CreatedBy == userID)
               .OrderBy(u => u.PassengerId)
               .ToList();
        }
        public void CreatePassenger(TblPassenger passenger)
        {
            Create(passenger);
        }
        public void UpdatePassenger(TblPassenger passenger)
        {
            Update(passenger);
        }
        public void DeletePassenger(TblPassenger passenger)
        {
            Delete(passenger);
        }


    }
}
