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
            var sessionIdBytes = context.HttpContext.Session
                .Get(Constant.SessionKey.Id);

            var sessionId = sessionIdBytes != null 
                ? Encoding.Default.GetString(sessionIdBytes) 
                : null;

            if(string.IsNullOrEmpty(sessionId))
                context.HttpContext.Response
                    .Redirect("/Auth/Login");
            else
            {
                context.HttpContext.Session
                    .Remove(Constant.SessionKey.Id);
                context.HttpContext.Session
                    .Set(Constant.SessionKey.Id, sessionIdBytes);
            }

            base.OnActionExecuting(context);
        }
    }
}
