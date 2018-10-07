using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class DiscountController : BaseController
    {
        public DiscountController(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult Index()
        {
            var model = new List<Discount>();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlDiscount);
                var response = Requestor().Get<CollectionResponse<Discount>>(url);

                CheckResponse(response);

                model = response.Collection;
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(string id)
        {
            var model = new Discount();

            try
            {
                var response = Fetch(id);

                CheckResponse(response);

                model = response.Collection.FirstOrDefault();
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        public IActionResult Get(string id) 
        {
            return Json(Fetch(id));
        }

        public IActionResult Delete(string id)
        {
            try
            {
                var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlDiscount)}{id}";
                var response = Requestor().Delete<BaseReponse>(url);

                CheckResponse(response);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { err = e.Message });
            }
        }
        
        [HttpPost]
        public IActionResult InsertOrUpdate(string code, string type,  decimal value, string mode)
        {
            try
            {
                BaseReponse response;
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlDiscount);
                var requestor = Requestor();
                var request = new Discount()
                {
                    Code = code,
                    Type = type,
                    Value = value
                };

                switch (mode)
                {
                    case "insert":
                        response = requestor.Post<BaseReponse>(url, request);
                        break;
                    case "update":
                        response = requestor.Put<BaseReponse>(url, request);
                        break;

                    default:
                        throw new Exception("mode not valid");
                }

                CheckResponse(response);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new {err = e.Message});
            }
        }

        private CollectionResponse<Discount> Fetch(string code)
        {
            var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlDiscount)}{code}";
            var response = Requestor().Get<CollectionResponse<Discount>>(url);

            return response;
        }
    }
}