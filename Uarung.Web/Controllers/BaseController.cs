﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (Request.QueryString.HasValue)
            {
                Request.Query.TryGetValue("err", out var errorMessage);
                Request.Query.TryGetValue("ok", out var okMessage);

                if (!string.IsNullOrEmpty(errorMessage))
                    SetErrorMessage(errorMessage);

                if (!string.IsNullOrEmpty(okMessage))
                    SetOkMessage(okMessage);
            }

            base.OnActionExecuted(context);
        }

        public string CreateServiceUrl(string urlConfigKeys)
        {
            return $"{GetConfigValue(Constant.ConfigKey.ApiHost)}{GetConfigValue(urlConfigKeys)}";
        }

        public string GetConfigValue(string key)
        {
            return _configuration.GetValue<string>(key);
        }

        private Dictionary<string, string> GetApiSessionIdHeader()
        {
            const string sessionIdKey = Constant.SessionKey.SessionId;
            var sessionId = HttpContext.Session.GetValue(sessionIdKey);

            return new Dictionary<string, string> {{sessionIdKey, sessionId}};
        }

        public Requestor Requestor()
        {
            return new Requestor(GetApiSessionIdHeader());
        }

        public void SetOkMessage(string okMessage)
        {
            ViewData[Constant.ViewDataKey.OkMessage] = okMessage;
        }

        public void SetErrorMessage(string errorMessage)
        {
            Console.WriteLine(errorMessage);

            ViewData[Constant.ViewDataKey.ErrorMessage] = errorMessage;
        }

        public void SetErrorMessage(Exception exception)
        {
            Console.WriteLine(exception);

            SetErrorMessage(exception.Message);
        }

        public void CheckResponse(BaseResponse response)
        {
            if (response.Status.Type.Equals(Constant.Status.TypeError))
                throw new Exception(response.Status.Message);
        }

        public void CheckResponse(IEnumerable<BaseResponse> responses)
        {
            foreach (var r in responses)
                CheckResponse(r);
        }
    }
}