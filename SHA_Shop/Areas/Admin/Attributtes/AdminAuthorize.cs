using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHA_Shop.Areas.Admin.Attributtes
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                        {
                                { "area", "Admin" },
                                { "controller", "User" },
                                { "action", "Login" },
                                { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                        });
            }
        }
    }
}