using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Reference.Interfaces
{
    public interface IDiscountsRepository : IRepositoryBase<TblDiscount>
    {
        IEnumerable<TblDiscount> GetAllDiscounts();
        TblDiscount GetDiscountById(long flightID);
        TblDiscount GetDiscountByCode(string discountCode);
        void CreateDiscount(TblDiscount discountsMaster);
        void UpdateDiscount(TblDiscount discountsMaster);
        void DeleteDiscount(TblDiscount discountsMaster);
    }
}
