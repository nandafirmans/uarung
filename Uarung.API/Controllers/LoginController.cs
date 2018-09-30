using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Uarung.API.Utility;
using Uarung.Data.Contract;
using Uarung.Model;

namespace Uarung.API.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IDacUser _dacUser;
        private readonly RedisManager _distributedCache;

        public LoginController(IDistributedCache distributedCache, IDacUser dacUser)
        {
            _dacUser = dacUser;
            _distributedCache = new RedisManager(distributedCache);
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

                SetSessionIdCache(key, request.Username, TimeSpan.FromMinutes(20));

                response.SessionId = key;
                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        private void SetSessionIdCache(string key, string value, TimeSpan? lifeTime)
        {
            _distributedCache.Set($"{Constant.Session.RedisNamespace}:{key}", value, lifeTime); 
        }
    }
}