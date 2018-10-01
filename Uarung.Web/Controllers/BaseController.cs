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
    }
}
