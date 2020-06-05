using OnlineShoppingApp.UI.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.ControllerUtilities
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        private readonly string[] authorizedRoles;

        public AuthorizeUserAttribute(params string[] roles)
        {
            this.authorizedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isUserAuthorized = false;
            User user = (User)httpContext.Session["CurrentUser"];

            if(user.Role != null)
            {
                if(authorizedRoles.Any(x => x == user.Role.RoleName))
                {
                    isUserAuthorized = true;
                }
            }

            return isUserAuthorized;
        }
    }
}