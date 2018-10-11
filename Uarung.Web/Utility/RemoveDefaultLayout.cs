using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Uarung.Web.Utility
{
    public class RemoveDefaultLayout : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}