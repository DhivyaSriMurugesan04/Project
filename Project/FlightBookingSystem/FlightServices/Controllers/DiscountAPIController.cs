using AutoMapper;
using DAL_Reference.Interfaces;
using DAL_Reference.Models;
using DAL_Reference.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/flight/[controller]")]
    [ApiController]
    public class DiscountAPIController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public DiscountAPIController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllDiscounts()
        {
            try
            {
                var Discounts = _repository.TblDiscounts.GetAllDiscounts();
                return Ok(Discounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }

        }


        [Route("byCode/{id}")]
        [HttpGet]
        public IActionResult GetDiscountByCode(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Please provide valid discount code");
                }
                var discount = _repository.TblDiscounts.GetDiscountByCode(id.ToString());
                return Ok(discount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }

        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateDiscount([FromBody] DiscountCreateDto discount)
        {
            try
            {
                if (discount == null)
                {
                    return BadRequest("Discount object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var discountEntity = _mapper.Map<TblDiscount>(discount);
                Random rnd = new Random();
                discountEntity.DiscountCode = rnd.Next(1, 9999).ToString();
                discountEntity.Status = "Active";
                discountEntity.CreatedBy = discount.UserID;
                discountEntity.CreatedDate = DateTime.Now;
                discountEntity.ModifiedDate = DateTime.Now;

                _repository.TblDiscounts.CreateDiscount(discountEntity);
                _repository.Save();

                return Ok(new { Message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("{id}")]
        public IActionResult UpdateDiscount(int id, [FromBody] DiscountCreateDto discount)
        {
            try
            {
                if (discount == null || id <= 0)
                {
                    return BadRequest("Discount object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var discountEntity = _repository.TblDiscounts.GetDiscountById(id);
                if (discountEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(discount, discountEntity);


                discountEntity.ModifiedDate = DateTime.Now;
                discountEntity.ModifiedBy = discount.UserID;
                _repository.TblDiscounts.Update(discountEntity);
                _repository.Save();
                return Ok(new { Message = "Updated Successfully" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(long id)
        {
            try
            {

                var discountEntity = _repository.TblDiscounts.GetDiscountById(id);
                if (discountEntity == null)
                {
                    return NotFound();
                }
                _repository.TblDiscounts.Delete(discountEntity);
                _repository.Save();

                return Ok(new { Message = "Deleted Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
