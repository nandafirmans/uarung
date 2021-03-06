using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

        [RemoveDefaultLayout]
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
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlLogin);
                response = Requestor().Post<LoginResponse>(url, request);
            }
            catch (Exception e)
            {
                response.Status.SetError(e.Message);
            }

            if (response.Status.Type.Equals(Constant.Status.TypeError))
                return RedirectToAction("Login", new {err = response.Status.Message});

            var jsonUser = JsonConvert.SerializeObject(response.User);

            HttpContext.Session.Set(
                Constant.SessionKey.SessionId,
                Encoding.Default.GetBytes(response.SessionId));

            HttpContext.Session.Set(
                Constant.SessionKey.JsonUser, 
                Encoding.Default.GetBytes(jsonUser));

            return RedirectToAction("Index", "Home");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
