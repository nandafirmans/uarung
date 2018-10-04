using System;
using System.Linq;
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
        private readonly RedisWrapper _redisWrapper;

        public Authorize(IDistributedCache distributedCache, IConfiguration configuration)
        {
            _configuration = configuration;
            _redisWrapper = new RedisWrapper(distributedCache);
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
                .TryGetValue(Constant.SessionKey.SessionId, out var sessionIdRequest);

            var sessionIdKey = $"{Constant.SessionKey.RedisNamespace}:{sessionIdRequest}";
            var sessionIdCacheValue = _redisWrapper.Get(sessionIdKey);

            if (!string.IsNullOrEmpty(sessionIdCacheValue))
            {
                var ltInMinutes = TimeSpan.FromMinutes(
                    _configuration.GetValue<int>(Constant.ConfigKey.SessionIdLifeTime));

                _redisWrapper.Remove(sessionIdKey);
                _redisWrapper.Set(sessionIdKey, sessionIdCacheValue, ltInMinutes);

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