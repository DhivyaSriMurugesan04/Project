using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Reference.Repository
{
    public class DiscountsRepo : RepositoryBase<TblDiscount>, IDiscountsRepository
    {
        public DiscountsRepo(FlightBookingApplicationDBContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public IEnumerable<TblDiscount> GetAllDiscounts()
        {
            return FindAll()
               .OrderBy(u => u.DiscountId)
               .ToList();
        }

        public TblDiscount GetDiscountById(long DiscountId)
        {
            return FindByCondition(u => u.DiscountId == DiscountId).FirstOrDefault();
        }
        public TblDiscount GetDiscountByCode(string discountCode)
        {
            return FindByCondition(u => u.DiscountCode.ToLower() == discountCode.ToLower()).FirstOrDefault();
        }
        public void CreateDiscount(TblDiscount discountsMaster)
        {
            Create(discountsMaster);
        }
        public void UpdateDiscount(TblDiscount discountsMaster)
        {
            Update(discountsMaster);
        }
        public void DeleteDiscount(TblDiscount discountsMaster)
        {
            Delete(discountsMaster);
        }


    }
}
