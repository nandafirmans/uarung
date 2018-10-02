using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Models;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IConfiguration configuration) 
            : base(configuration)
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Product()
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

        [Authorize]
        public IActionResult ProductCategory()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
