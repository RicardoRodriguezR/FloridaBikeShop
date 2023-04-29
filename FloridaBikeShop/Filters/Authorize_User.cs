using FloridaBikeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloridaBikeShop.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Authorize_User : AuthorizeAttribute
    {
        private Propietario db_Ususario;
        private FloridaBikeShopEntities db_Propietario = new FloridaBikeShopEntities();
        private int idOperacion;

        public Authorize_User(int idOperacion = 1)
        {
            this.idOperacion = idOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                db_Ususario = (Propietario)HttpContext.Current.Session["Usuario"];
                var lstMisOperaciones = from d in db_Propietario.Propietario
                                        where d.rol == db_Ususario.rol
                                        select d;
                if (lstMisOperaciones.ToList().Count() < 1)
                {
                    
                }
            }
            catch { }
        }


    }
}