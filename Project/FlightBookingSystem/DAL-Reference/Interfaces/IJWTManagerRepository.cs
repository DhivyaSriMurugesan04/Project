using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IJWTManagerRepository
    {
        Tokens Authentication(string email, string password);
    }
}
