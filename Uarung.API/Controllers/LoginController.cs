using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Uarung.API.Model;
using Uarung.API.Utility;

namespace Uarung.API.Controllers
{
    public class LoginController : BaseController
    {
        private readonly RedisManager _redisManager;

        public LoginController(IConfiguration configuration)
        {
            _redisManager = new RedisManager(configuration);
        }

        [HttpPost]
        [UnAuthorize]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var response = new LoginResponse();

            try
            {
                if (request.Username != "admin" || request.Password != "admin")
                    throw new Exception("");
                
                var keys = Guid.NewGuid().ToString("N");

                _redisManager.Set(
                    $"{Constant.Session.RedisNamespace}:{keys}", 
                    request.Username, 
                    TimeSpan.FromMinutes(1));

                response.SessionId = keys;

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }
    }
}