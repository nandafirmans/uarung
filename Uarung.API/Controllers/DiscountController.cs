using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Uarung.API.Utility;
using Uarung.Data.Contract;
using Uarung.Model;

namespace Uarung.API.Controllers
{
    public class DiscountController : BaseController
    {
        private readonly IDacDiscount _dacDiscount;
        private readonly RedisWrapper _redisWrapper;

        public DiscountController(IDacDiscount dacDiscount, IDistributedCache distributedCache)
        {
            _dacDiscount = dacDiscount;
            _redisWrapper = new RedisWrapper(distributedCache);
        }

        [HttpPost]
        public ActionResult<BaseReponse> Create(Discount request)
        {
            var response = new BaseReponse();

            try
            {
                var userId = GetUserId(Request, _redisWrapper);
                var discount = new Data.Entity.Discount
                {
                    Id = request.Code,
                    UserId = userId,
                    Type = request.Type,
                    Value = request.Value
                };

                _dacDiscount.Insert(discount);
                _dacDiscount.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e);
            }

            return response;
        }

        [HttpPut]
        public ActionResult<BaseReponse> Update(Discount request)
        {
            var response = new BaseReponse();

            try
            {
                var discount = _dacDiscount.Single(request.Code);

                if (discount == null)
                    throw new Exception("data not exist");

                if (discount.Id != request.Code)
                    discount.Id = request.Code;

                if (discount.Type != request.Type)
                    discount.Type = request.Type;

                if (discount.Value != request.Value)
                    discount.Value = request.Value;

                _dacDiscount.Update(discount);
                _dacDiscount.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e);
            }

            return response;
        }

        [HttpGet("{id=}")]
        public ActionResult<CollectionResponse<Discount>> Get(string id)
        {
            var response = new CollectionResponse<Discount>();

            try
            {
                var isEmpty = string.IsNullOrEmpty(id);
                var discounts = (isEmpty
                        ? _dacDiscount.All()
                        : new[] { _dacDiscount.Single(id) })
                    .ToList();

                if(!isEmpty && discounts.FirstOrDefault() == null) 
                    throw new Exception("data not found");

                response.Collection = discounts?
                    .Select(d => new Discount()
                    {
                        Code = d.Id,
                        Type = d.Type,
                        Value = d.Value
                    })
                    .ToList();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e);
            }

            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<BaseReponse> Delete(string id)
        {
            var response = new BaseReponse();

            try
            {

                var discount = _dacDiscount.Single(id);

                if (discount == null)
                    throw new Exception("data not found");

                _dacDiscount.Delete(discount);
                _dacDiscount.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e);
            }

            return response;
        }
    }
}