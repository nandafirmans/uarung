using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Models;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class TransactionController : BaseController
    {
        public TransactionController(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult SalesRegister()
        {
            var model = new SalesRegisterViewModel();
            ViewData[Constant.ConfigKey.ApiHost] = GetConfigValue(Constant.ConfigKey.ApiHost);
            
            try
            {
                var requestor = Requestor();
                var urlCategories = CreateServiceUrl(Constant.ConfigKey.ApiUrlProductCategory);
                var urlProduct = CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct);
                var responseCategory = requestor.Get<CollectionResponse<ProductCategory>>(urlCategories);
                var responseProduct = requestor.Get<CollectionResponse<Product>>(urlProduct);

                CheckResponse(new BaseReponse[] {responseCategory, responseProduct});

                model.Categories = new List<ProductCategory> {new ProductCategory {Id = "0", Name = "All"}}
                    .Concat(responseCategory.Collection)
                    .ToList();

                model.Products = responseProduct.Collection;
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }
    }
}