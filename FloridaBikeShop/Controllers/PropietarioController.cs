using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FloridaBikeShop.Models;
using FloridaBikeShop.Models.ViewModels;
using FloridaBikeShop.Models.ViewModels.Bicicleta_Models;

namespace FloridaBikeShop.Controllers
{
    public class PropietarioController : Controller
    {
        // Listas Para mostrar ----------------------------------

        public ActionResult ListaPropietarios()
        {
            List<Modelo_Propietario>lst;
            using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
            {
                lst = (from propietario in db.Propietario 
                       select new Modelo_Propietario
                        {
                            Id = propietario.ID,
                            Documento = propietario.documento,
                            Nombre = propietario.nombre,
                            Apellido = propietario.apellido,
                            Telefono = propietario.telefono,
                            Direccion = propietario.direccion

                        }).ToList();
            }
                return View(lst);
        }

        public ActionResult ListaInformacionCompleta()
        {
            List<Modelo_Propietario> lst;
            using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
            {
                lst = (from bicicleta in db.Bicicleta
                       join propietario in db.Propietario on bicicleta.fk_propietario equals propietario.ID
                       select new Modelo_Propietario
                       {
                           Id = propietario.ID,
                           Documento = propietario.documento,
                           Nombre = propietario.nombre,
                           Apellido = propietario.apellido,
                           Telefono = propietario.telefono,
                           Direccion = propietario.direccion,
                           Tipo = bicicleta.tipo,
                           Marca = bicicleta.marca,
                           Valor_Bicicleta = bicicleta.valor_bicicleta

                       }).ToList();
            }
            return View(lst);
        }

        //CRUD PROPIETARIO -----------------------------------

        public ActionResult NuevoPropietario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoPropietario(Formulario_Propietario model)
        {
            if (ModelState.IsValid)
            {
                using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
                {
                    var db_Propietario = new Propietario();
                    db_Propietario.documento = model.Documento;
                    db_Propietario.nombre = model.Nombre;
                    db_Propietario.apellido = model.Apellido;
                    db_Propietario.telefono = model.Telefono;
                    db_Propietario.direccion = model.Direccion;

                    db.Propietario.Add(db_Propietario);
                    db.SaveChanges();
                }
                return Redirect("~/Propietario/NuevaBicicleta");
            }
            return View(model);
        }

        public ActionResult EditarPropietario(int Id)
        {
            Formulario_Propietario model = new Formulario_Propietario();
            using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
            {
                var db_Propietario = db.Propietario.Find(Id);

                model.Documento = db_Propietario.documento;
                model.Nombre = db_Propietario.nombre;
                model.Apellido = db_Propietario.apellido;
                model.Telefono = db_Propietario.telefono;
                model.Direccion = db_Propietario.direccion;
            }
            return View(model);

        }

        [HttpPost]
        public ActionResult EditarPropietario(Formulario_Propietario model)
        {
            if (ModelState.IsValid)
            {
                using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
                {
                    var db_Propietario = db.Propietario.Find(model.Id_Propietario);

                    db_Propietario.documento = model.Documento;
                    db_Propietario.nombre = model.Nombre;
                    db_Propietario.apellido = model.Apellido;
                    db_Propietario.telefono = model.Telefono;
                    db_Propietario.direccion = model.Direccion;
                    
                    db.Entry(db_Propietario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Redirect("~/Propietario/ListaPropietarios");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult EliminarPropietario(int Id)
        {
            using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
            {
                var oTabla = db.Propietario.Find(Id);
                db.Propietario.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Propietario/ListaPropietarios");
        }

        //CRUD BICICLETA ------------------------------------

        public ActionResult NuevaBicicleta()
        {
            List<Modelo_Propietario> lst;
            using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
            {
                lst = (from propietario in db.Propietario
                       select new Modelo_Propietario
                       {
                           Id = propietario.ID,
                           Nombre = propietario.nombre,
                           Apellido = propietario.apellido,
                       }).ToList();
            }

            List<SelectListItem> item = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString() + " " + d.Apellido.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = item; 

            return View();
        }

        [HttpPost]
        public ActionResult NuevaBicicleta(Formulario_Bicicleta model)
        {
            if (ModelState.IsValid)
            {
                using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
                {
                    var db_Bicicleta = new Bicicleta();
                    var db_Propietario = new Propietario();

                    db_Bicicleta.tipo = model.Tipo;
                    db_Bicicleta.marca = model.Marca;
                    db_Bicicleta.valor_bicicleta = model.Valor_Bicicleta;
                    db_Bicicleta.fecha_compra = model.Fecha_compra;
                    db_Bicicleta.Propietario = model.Propietario;

                    db.Bicicleta.Add(db_Bicicleta);
                    db.SaveChanges();

                }
                return Redirect("~/Propietario/ListaInformacionCompleta");
            }
            return View(model);
        }

        public ActionResult EditarBicicleta(int Id)
        {
            Formulario_Bicicleta model = new Formulario_Bicicleta();
            using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
            {
                var db_Bicicleta = db.Bicicleta.Find(Id);

                model.Tipo = db_Bicicleta.tipo;
                model.Marca = db_Bicicleta.marca;
                model.Valor_Bicicleta = db_Bicicleta.valor_bicicleta;
                model.Fecha_compra = db_Bicicleta.fecha_compra;
                model.Propietario = db_Bicicleta.Propietario;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarBicicleta(Formulario_Bicicleta model)
        {
            if (ModelState.IsValid)
            {
                using (FloridaBikeShopEntities db = new FloridaBikeShopEntities())
                {
                    var db_Bicicleta = db.Bicicleta.Find(model.Id_Bicicleta);

                    db_Bicicleta.tipo = model.Tipo;
                    db_Bicicleta.marca = model.Marca;
                    db_Bicicleta.valor_bicicleta = model.Valor_Bicicleta;
                    db_Bicicleta.fecha_compra = model.Fecha_compra;
                    db_Bicicleta.Propietario = model.Propietario;

                    db.Entry(db_Bicicleta).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Redirect("~/Propietario/ListaInformacionCompleta");
            }
            return View(model);
        }
    }

}

