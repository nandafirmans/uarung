using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Uarung.Model;
using Uarung.Web.Models;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IConfiguration configuration) 
            : base(configuration)
        {
        }
        
        public IActionResult Index()
        {
             var userName = string.Empty;

            try
            {
                userName = HttpContext.Session
                    .GetValue<User>(Constant.SessionKey.JsonUser)?.Name;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            ViewData[Constant.ViewDataKey.UserName] = userName;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
