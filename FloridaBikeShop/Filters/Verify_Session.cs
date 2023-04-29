using FloridaBikeShop.Controllers;
using FloridaBikeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloridaBikeShop.Filters
{
    public class Verify_Session : ActionFilterAttribute
    {
        private Propietario db_Propietario;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);

                db_Propietario = (Propietario)HttpContext.Current.Session["User"];
                if (db_Propietario == null)
                {
                    if (filterContext.Controller is HomeController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Home/Index");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Home/Index"); 
            }
        }
    }
}