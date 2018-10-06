using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class TransactionController : BaseController
    {
        public TransactionController(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult SalesRegister()
        {
            return View();
        }
    }
}