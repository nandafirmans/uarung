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
            var model = new List<Transaction>();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlTransaction);
                var response = Requestor().Get<CollectionResponse<Transaction>>(url);

                CheckResponse(response);

                model = response.Collections;
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
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
                    .Concat(responseCategory.Collections)
                    .ToList();

                model.Products = responseProduct.Collections;
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(string id, [FromBody] Transaction request)
        {
            var response = new CollectionResponse<Transaction>();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlTransaction);

                response = id.Equals("update") 
                    ? Requestor().Put<CollectionResponse<Transaction>>(url, request) 
                    : Requestor().Post<CollectionResponse<Transaction>>(url, request);
            }
            catch (Exception e)
            {
                response.Status.SetError(e.Message);
            }

            return Json(response);
        }
        
        [HttpGet]
        public IActionResult GetHoldOnly() 
        {
            var response = new CollectionResponse<Transaction>();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlTransactionGetHold);
                response = Requestor().Get<CollectionResponse<Transaction>>(url);
            }
            catch (Exception e)
            {
                response.Status.SetError(e.Message);
            }

            return Json(response);
        }
    }
}