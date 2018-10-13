using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Uarung.Model;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public UserController(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult Index()
        {
            var model = new List<User>();
            var currentUserId = string.Empty;

            try
            {
                model = FetchUser().Collections;
                currentUserId = HttpContext.Session
                    .GetValue<User>(Constant.SessionKey.JsonUser)?.Id;
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            ViewData[Constant.ViewDataKey.UserId] = currentUserId;

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(string id)
        {
            var model = new User();

            try
            {
                model = FetchUser(id).Collections.FirstOrDefault();
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlUser)}{id}";
                var response = Requestor().Delete<BaseReponse>(url);

                CheckResponse(response);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new {err = e.Message});
            }
        }

        [HttpPost]
        public IActionResult Submit(User user)
        {
            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlUser);

                var response = string.IsNullOrEmpty(user.Id) 
                    ? Requestor().Post<BaseReponse>(url, user)
                    : Requestor().Put<BaseReponse>(url, user);

                CheckResponse(response);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new {err = e.Message});
            }
        }

        private CollectionResponse<User> FetchUser(string id = "")
        {
            var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlUser)}{id}";
            var response = Requestor().Get<CollectionResponse<User>>(url);

            CheckResponse(response);

            return response;
        }
    }
}