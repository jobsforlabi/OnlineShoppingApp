using Microsoft.Web.Mvc;
using OnlineShoppingApp.UI.ControllerUtilities;
using OnlineShoppingApp.UI.Models;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Controllers
{
    [HandleExceptionFilter]
    public abstract class OnlineShoppingBaseController : Controller
    {
        public User CurrentUser
        {
            get
            {
                return (User)Session["CurrentUser"];
            }
            set
            {
                Session["CurrentUser"] = value;
            }
        }

        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action)
                                                        where TController : Controller
        {
            return ControllerExtensions.RedirectToAction<TController>(this, action);
        }
    }
}