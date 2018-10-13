using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Uarung.API.Utility;
using Uarung.Data.Contract;
using Uarung.Model;

namespace Uarung.API.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _distributedCache;
        private readonly IDacUser _dacUser;

        public LoginController(IDistributedCache distributedCache, IDacUser dacUser, IConfiguration configuration)
        {
            _distributedCache = distributedCache;
            _dacUser = dacUser;
            _configuration = configuration;
        }

        [HttpPost]
        [UnAuthorize]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var response = new LoginResponse();

            try
            {
                var passwordHashed = Crypt.ToSHA256(request.Password);
                var user = _dacUser.Single(
                    u => u.Username.Equals(request.Username) && u.Password.Equals(passwordHashed));

                if (user == null)
                    throw new Exception("username or password doesn't match");

                var key = Guid.NewGuid().ToString("N");

                SetSessionIdCache(key, JsonConvert.SerializeObject(user));

                response.SessionId = key;
                response.User = new User
                {
                    Id = user.Id,
                    Email = user.Email,
                    Gender = user.Gender,
                    Name = user.Name,
                    Role = user.Role,
                    Username = user.Username,
                    Phone = user.Phone
                };

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
            var lifeTimeConfig = _configuration.GetValue<int>(Constant.ConfigKey.SessionIdLifeTime);
            var cacheKey = $"{Constant.SessionKey.RedisNamespace}:{key}";

            _distributedCache.SetValue(cacheKey, value, TimeSpan.FromMinutes(lifeTimeConfig));
        }
    }
}