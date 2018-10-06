using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return redisWrapper.Get($"{Constant.SessionKey.RedisNamespace}:{request.Headers[Constant.SessionKey.SessionId]}");
        }
    }
}