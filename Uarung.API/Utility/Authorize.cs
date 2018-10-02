using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Uarung.Model;

namespace Uarung.API.Utility
{
    public class Authorize : IActionFilter
    {
        private readonly IConfiguration _configuration;
        private readonly RedisManager _distributedCache;

        public Authorize(IDistributedCache distributedCache, IConfiguration configuration)
        {
            _configuration = configuration;
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
                .TryGetValue(Constant.SessionKey.Id, out var sessionIdRequest);

            var sessionIdKey = $"{Constant.SessionKey.RedisNamespace}:{sessionIdRequest}";
            var sessionIdCacheValue = _distributedCache.Get(sessionIdKey);

            if (!string.IsNullOrEmpty(sessionIdCacheValue))
            {
                var ltInMinutes = TimeSpan.FromMinutes(
                    _configuration.GetValue<int>(Constant.ConfigKey.SessionIdLifeTime));

                _distributedCache.Remove(sessionIdKey);
                _distributedCache.Set(sessionIdKey, sessionIdCacheValue, ltInMinutes);

                return;
            }

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