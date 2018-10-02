using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public IActionResult Login(string err)
        {
            ViewData[Constant.ViewDataKey.ErrorMessage] = string.IsNullOrEmpty(err) 
                ? string.Empty
                : err;

            return View();
        }

        [HttpPost]
        public IActionResult Validate(LoginRequest request)
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

            if (response.Status.Type.Equals(Constant.Status.TypeError))
                return RedirectToAction("Login", new {err = response.Status.Message});


            HttpContext.Session.Set(
                Constant.SessionKey.Id,
                Encoding.Default.GetBytes(response.SessionId));

            return RedirectToAction("Index", "Home");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
