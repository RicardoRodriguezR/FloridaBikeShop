using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloridaBikeShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Password)
        {
            try
            {
                using (Models.FloridaBikeShopEntities db = new Models.FloridaBikeShopEntities())
                {
                    var db_User = (from db_Propietario in db.Propietario
                                   where db_Propietario.email == User.Trim() && db_Propietario.password == Password.Trim()
                                   select db_Propietario).FirstOrDefault();
                    if (db_User == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalido";
                        return View();
                    }

                    Session["User"] = db_User;
                }
                    return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}