using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL_Reference.Repository
{
    public class UserRepo : RepositoryBase<TblUser>, Interfaces.IUserRepository
    {
        public UserRepo(FlightBookingApplicationDBContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<TblUser> GetAllUsers()
        {
            return FindAll()
               .OrderBy(u => u.UserId)
               .ToList();
        }

        public TblUser GetUserById(string UserId)
        {
            return FindByCondition(u => u.UserId == UserId).FirstOrDefault();
        }
        public TblUser GetUserByEmailAndPwd(string email, string pwd)
        {
            return FindByCondition(u => u.EmailId.ToLower() == email.ToLower() && u.PassWord.ToLower() == pwd.ToLower()).FirstOrDefault();
        }

        public void CreateUser(TblUser usersMaster)
        {
            Create(usersMaster);
        }
        public void UpdateUser(TblUser usersMaster)
        {
            Update(usersMaster);
        }
        public void DeleteUser(TblUser usersMaster)
        {
            Delete(usersMaster);
        }

        
    }
}
