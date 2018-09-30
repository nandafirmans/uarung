using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Uarung.Model;

namespace Uarung.API.Utility
{
    public class Authorize : IActionFilter
    {
        private readonly RedisManager _distributedCache;

        public Authorize(IDistributedCache distributedCache)
        {
            _distributedCache = new RedisManager(distributedCache);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isUnAuth = context.ActionDescriptor.FilterDescriptors
                .Any(f => f.Filter.GetType() == typeof(UnAuthorize));

            if (isUnAuth) return;

            context.HttpContext.Request.Headers
                .TryGetValue(Constant.RequestKey.SessionId, out var sessionId);

            if (!string.IsNullOrEmpty(GetSessionIdCache(sessionId)))
                return;

            var response = new BaseReponse();
            response.Status.SetError("session id required");

            context.Result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(response),
                ContentType = "application/json"
            };
        }

        private string GetSessionIdCache(string key)
        {
            return _distributedCache.Get($"{Constant.Session.RedisNamespace}:{key}");
        }
    }
}