using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IUsersMasterRepository : IRepositoryBase<TblUser>
    {
        IEnumerable<TblUser> GetAllUsers();
        TblUser GetUserById(int UserId);

        TblUser GetUserByEmailAndPwd(string email, string pwd);
        void CreateUser(TblUser usersMaster);
        void UpdateUser(TblUser usersMaster);
        void DeleteUser(TblUser usersMaster);
    }
}
