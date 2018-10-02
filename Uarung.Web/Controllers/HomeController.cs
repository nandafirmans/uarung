using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
