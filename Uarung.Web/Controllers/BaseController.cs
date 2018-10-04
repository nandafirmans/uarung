using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;

namespace Uarung.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateServiceUrl(string urlConfigKeys)
        {
            return $"{GetConfigValue(Constant.ConfigKey.ApiHost)}{GetConfigValue(urlConfigKeys)}";
        }

        public string GetConfigValue(string key)
        {
            return _configuration.GetValue<string>(key);
        }

        public Dictionary<string, string> GetApiSessionIdHeader()
        {
            const string sessionIdKey = Constant.SessionKey.SessionId;
            var sessionId = GetSessionValue(sessionIdKey);

            return new Dictionary<string, string> {{sessionIdKey, sessionId}};
        }

        public string GetSessionValue(string key)
        {
            var sessionValueBytes = HttpContext.Session.Get(key);

            return sessionValueBytes != null
                ? Encoding.Default.GetString(sessionValueBytes)
                : string.Empty;
        }
    }
}