using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Uarung.API.Utility;
using Uarung.Data.Contract;
using Uarung.Model;

namespace Uarung.API.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IDacUser _dacUser;
        private readonly IConfiguration _configuration;
        private readonly RedisWrapper _redisWrapper;

        public LoginController(IDistributedCache distributedCache, IDacUser dacUser, IConfiguration configuration)
        {
            _dacUser = dacUser;
            _configuration = configuration;
            _redisWrapper = new RedisWrapper(distributedCache);
        }

        [HttpPost]
        [UnAuthorize]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var response = new LoginResponse();

            try
            {
                var passwordHashed = Crypt.ToSHA256(request.Password);
                var user = _dacUser.Single(u => u.Username.Equals(request.Username) && u.Password.Equals(passwordHashed));

                if (user == null)
                    throw new Exception("username or password doesn't match");
                
                var key = Guid.NewGuid().ToString("N");

                SetSessionIdCache(key, user.Id);

                response.SessionId = key;
                response.UserId = user.Id;
                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e.Message);
            }

            return response;
        }

        private void SetSessionIdCache(string key, string value)
        {
            var ltInMinutes = TimeSpan.FromMinutes(
                _configuration.GetValue<int>(Constant.ConfigKey.SessionIdLifeTime));

            _redisWrapper.Set($"{Constant.SessionKey.RedisNamespace}:{key}", value, ltInMinutes); 
        }
    }
}