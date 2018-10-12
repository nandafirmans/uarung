using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uarung.API.Utility;
using Uarung.Model;

namespace Uarung.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected static string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
        
        protected static string GetUserId(HttpRequest request, RedisWrapper redisWrapper)
        {
            var cacheKey = $"{Constant.SessionKey.RedisNamespace}:{request.Headers[Constant.SessionKey.SessionId]}";
            var jsonUser = redisWrapper.Get(cacheKey);

            if (string.IsNullOrEmpty(jsonUser))
                throw new Exception("user id is required");

            var user = JsonConvert.DeserializeObject<User>(jsonUser);

            return user.Id;
        }
    }
}