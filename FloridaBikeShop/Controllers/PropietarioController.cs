using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FloridaBikeShop.Models;
using FloridaBikeShop.Models.ViewModels;

namespace FloridaBikeShop.Controllers
{
    public class PropietarioController : Controller
    {
        // GET: Propietario
        public ActionResult ListaPropietarios()
        {
            List<ListaTablaPropietario>lst;
            using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
            {
                lst = (from d in db.Propietario
                        select new ListaTablaPropietario
                        {
                            Id = d.ID,
                            Documento = d.documento,
                            Nombre = d.nombre,
                            Apellido = d.apellido,
                            Telefono = d.telefono,
                            Direccion = d.direccion
                        }).ToList();
            }
                return View(lst);
        }

        public ActionResult NuevoPropietario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoPropietario(TablaNuevoPropietario model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
                    {
                        var oTabla = new Propietario();
                        oTabla.ID = model.Id;
                        oTabla.documento = model.Documento;
                        oTabla.nombre = model.Nombre;
                        oTabla.apellido = model.Apellido;
                        oTabla.telefono = model.Telefono;
                        oTabla.direccion = model.Direccion;

                        db.Propietario.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("Propietario/ListaPropietarios");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult EditarPropietario(int Id)
        {
            TablaNuevoPropietario model = new TablaNuevoPropietario();
            using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
            {
                var oTabla = db.Propietario.Find(Id);
                model.Documento = oTabla.documento;
                model.Nombre = oTabla.nombre;
                model.Apellido = oTabla.apellido;
                model.Telefono = oTabla.telefono;
                model.Direccion = oTabla.direccion;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditarPropietario(TablaNuevoPropietario model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
                    {
                        var oTabla = db.Propietario.Find(model.Id);
                        oTabla.documento = model.Documento;
                        oTabla.nombre = model.Nombre;
                        oTabla.apellido = model.Apellido;
                        oTabla.telefono = model.Telefono;
                        oTabla.direccion = model.Direccion;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("Propietario/Index_Propietario");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}