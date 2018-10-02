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
        protected readonly IConfiguration Configuration;

        public BaseController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string CreateServiceUrl(string urlConfigKeys)
        {
            return $"{GetConfigValue(Constant.ConfigKey.ApiHost)}{GetConfigValue(urlConfigKeys)}";
        }

        public string GetConfigValue(string key)
        {
            return Configuration.GetValue<string>(key);
        }

        public Dictionary<string, string> GetSessionHeaderId()
        {
            var sessionIdBytes = HttpContext.Session.Get(Constant.SessionKey.Id);
            var sessionId = sessionIdBytes != null
                ? Encoding.Default.GetString(sessionIdBytes)
                : string.Empty;

            return new Dictionary<string, string> {{Constant.SessionKey.Id, sessionId}};
        }
    }
}