using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Uarung.Model;

namespace Uarung.Web.Utility
{
    public class Authorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var sessionId = GetSessionValue(Constant.SessionKey.SessionId, context.HttpContext);
            var userJson = GetSessionValue(Constant.SessionKey.JsonUser, context.HttpContext);

            if (string.IsNullOrEmpty(sessionId) || string.IsNullOrEmpty(userJson))
            {
                context.HttpContext.Response.Redirect("/Auth/Login");
                return;
            }

            session.Clear();
            session.Set(Constant.SessionKey.SessionId, Encoding.Default.GetBytes(sessionId));
            session.Set(Constant.SessionKey.JsonUser, Encoding.Default.GetBytes(userJson));

            base.OnActionExecuting(context);
        }

        private static string GetSessionValue(string key, HttpContext context)
        {
            var sessionValueBytes = context.Session.Get(key);

            return sessionValueBytes != null
                ? Encoding.Default.GetString(sessionValueBytes)
                : string.Empty;
        }
    }
}