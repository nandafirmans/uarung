using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Uarung.API.Model;

namespace Uarung.API.Utility
{
    public class Authorize : IActionFilter
    {
        private readonly RedisManager _redisManager;

        public Authorize(IConfiguration configuration)
        {
            _redisManager = new RedisManager(configuration);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isAuth = context.ActionDescriptor.FilterDescriptors
                .Any(f => f.Filter.GetType() == typeof(UnAuthorize));

            if (isAuth) return;

            context.HttpContext.Request.Headers
                .TryGetValue(Constant.RequestKey.SessionId, out var sessionId);

            var sessionIdCache = _redisManager.Get($"{Constant.Session.RedisNamespace}:{sessionId}");

            if (!string.IsNullOrEmpty(sessionIdCache)) return;

            var response = new BaseReponse();

            response.Status.SetError("session id required");

            context.Result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(response),
                ContentType = "application/json"
            };
        }
    }
}