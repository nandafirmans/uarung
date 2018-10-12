using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Uarung.Model;
using User = Uarung.Data.Entity.User;

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
            if (CheckAttributes(context.ActionDescriptor, typeof(UnAuthorize)))
                return;

            var session = GetSessionIdCache(context.HttpContext).FirstOrDefault();

            if (string.IsNullOrEmpty(session.Value))
            {
                context.Result = CreateErrorMessage("session id required");
                return;
            }
            
            if (CheckAttributes(context.ActionDescriptor, typeof(CashierAllowed)))
            {
                ExtendSession(session.Key, session.Value);
                return;
            }
            
            if (GetUserRole(session.Value).Equals(Constant.UserRole.Cashier))
            {
                context.Result = CreateErrorMessage("you need permission to perform this action");
                return;
            }

            ExtendSession(session.Key, session.Value);
        }

        private void ExtendSession(string sessionIdKey, string jsonUser)
        {
            var configLifeTime = _configuration.GetValue<int>(Constant.ConfigKey.SessionIdLifeTime);

            _redisWrapper.Remove(sessionIdKey);
            _redisWrapper.Set(sessionIdKey, jsonUser, TimeSpan.FromMinutes(configLifeTime));
        }

        private static bool CheckAttributes(ActionDescriptor actionDescriptor, Type attributeType)
        {
            return actionDescriptor.FilterDescriptors
                .Any(f => f.Filter.GetType() == attributeType);
        }

        private Dictionary<string, string> GetSessionIdCache(HttpContext context)
        {
            context.Request.Headers
                .TryGetValue(Constant.SessionKey.SessionId, out var sessionIdRequest);

            var sessionIdKey = $"{Constant.SessionKey.RedisNamespace}:{sessionIdRequest}";
            var sessionIdCacheValue = _redisWrapper.Get(sessionIdKey);

            return new Dictionary<string, string>()
            {
                {sessionIdKey, sessionIdCacheValue}
            };
        }

        private static string GetUserRole(string userJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<User>(userJson).Role;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return string.Empty;
            }
        }

        private static ContentResult CreateErrorMessage(string message)
        {
            var response = new BaseReponse();

            response.Status.SetError(message);

            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(response),
                ContentType = "application/json"
            };
        }
    }
}