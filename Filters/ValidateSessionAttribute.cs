using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DignitaTask.Filters
{
    public class ValidateSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["trabajador"] == null)
            {
                filterContext.Result = new RedirectResult("~/Default/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}