using OnlineShoppingApp.Utility;
using System;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.ControllerUtilities
{
    public class HandleExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            OnlineShoppingApp.Utility.Exception exception = new OnlineShoppingApp.Utility.Exception()
            {
                LogTime = DateTime.Now,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                Message = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace
            };

            Log.Instance.LogException(exception);
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult() { ViewName = "Error" };
        }
    }
}