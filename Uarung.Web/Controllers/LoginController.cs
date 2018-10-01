using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public IActionResult Index(string errorMessage)
        {
            ViewData[Constant.ViewDataKey.ErrorMessage] = string.IsNullOrEmpty(errorMessage) 
                ? string.Empty
                : errorMessage;

            return View();
        }

        [HttpPost]
        public IActionResult Start(LoginRequest request)
        {
            var response = new LoginResponse();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiLogin);
                response = new Requestor().Post<LoginResponse>(url, request);
            }
            catch (Exception e)
            {
                response.Status.SetError(e.Message);
            }

            if (response.Status.Type.Equals(Constant.Status.TypeSuccess))
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", new { errorMessage = response.Status.Message });
        }
    }
}
