using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Uarung.Data.Contract;
using Uarung.Model;

namespace Uarung.API.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private readonly IDacProductCategory _dacProductCategory;

        public ProductCategoryController(IDacProductCategory dacProductCategory)
        {
            _dacProductCategory = dacProductCategory;
        }

        [HttpPost]
        public ActionResult<BaseReponse> Create(ProductCategory request)
        {
            var response = new BaseReponse();
            try
            {
                var category = new Data.Entity.ProductCategory
                {
                    Id = GenerateId(),
                    Name = request.Name
                };

                _dacProductCategory.Insert(category);
                _dacProductCategory.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpGet("{id=}")]
        public ActionResult<CollectionResponse<ProductCategory>> Get(string id)
        {
            var response = new CollectionResponse<ProductCategory>();

            try
            {
                var categories = (string.IsNullOrEmpty(id)
                        ? _dacProductCategory.All()
                        : new[] {_dacProductCategory.Single(id)})
                    .ToList();

                if(!categories.Any())
                    throw new Exception("result empty");    

                response.Collection = categories
                    .Select(c => new ProductCategory
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToList();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
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
                var category = _dacProductCategory.Single(id);

                if (category == null)
                    throw new Exception("data not found");

                _dacProductCategory.Delete(category);
                _dacProductCategory.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }
    }
}