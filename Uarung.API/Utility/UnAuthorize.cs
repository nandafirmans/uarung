using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Uarung.API.Utility
{
    public class UnAuthorize : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}