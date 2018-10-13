using Microsoft.AspNetCore.Mvc.Filters;
using Uarung.Model;

namespace Uarung.Web.Utility
{
    public class Authorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var sessionId = session.GetValue(Constant.SessionKey.SessionId);
            var userJson = session.GetValue(Constant.SessionKey.JsonUser);

            if (string.IsNullOrEmpty(sessionId) || string.IsNullOrEmpty(userJson))
            {
                context.HttpContext.Response.Redirect("/Auth/Login");
                return;
            }

            session.Clear();
            session.SetValue(Constant.SessionKey.SessionId, sessionId);
            session.SetValue(Constant.SessionKey.JsonUser, userJson);

            base.OnActionExecuting(context);
        }
    }
}