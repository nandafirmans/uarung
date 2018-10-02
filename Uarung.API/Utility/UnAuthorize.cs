using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Uarung.Model;

namespace Uarung.API.Utility
{
    public class UnAuthorize : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {   
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Request.Headers.Add("unAuth", $"{Guid.NewGuid():N}");
        }
    }
}