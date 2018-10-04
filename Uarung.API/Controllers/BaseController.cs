using System;
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

        protected static string GetUserId(string key, RedisWrapper redisWrapper)
        {
            return redisWrapper.Get($"{Constant.SessionKey.RedisNamespace}:{key}");
        }
    }
}