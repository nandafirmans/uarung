using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        public ProductController(IConfiguration configuration)
            : base(configuration)
        {
        }

        public IActionResult Index()
        {
            var response = new CollectionResponse<Product>();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiProduct);

                response = new Requestor(GetSessionHeaderId())
                    .Get<CollectionResponse<Product>>(url);
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return View();
        }

        public IActionResult Category()
        {
            var response = new CollectionResponse<ProductCategory>();
            List<ProductCategory> model = null;

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiProductCategory);

                response = new Requestor(GetSessionHeaderId())
                    .Get<CollectionResponse<ProductCategory>>(url);

                if (response.Status.Type.Equals(Constant.Status.TypeError))
                    throw new Exception(response.Status.Message);

                model = response.Collection;
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult InsertCategory(string name)
        {
            var response = new BaseReponse();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiProductCategory);

                response = new Requestor(GetSessionHeaderId())
                    .Post<BaseReponse>(url, new ProductCategory{ Name = name });
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return RedirectToAction("Category");
        }
        
        public IActionResult DeleteCategory(string id)
        {
            var response = new BaseReponse();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiProductCategory);

                response = new Requestor(GetSessionHeaderId())
                    .Delete<BaseReponse>($"{url}{id}");
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return RedirectToAction("Category");
        }
    }
}