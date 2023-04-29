using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FloridaBikeShop.Models;

namespace FloridaBikeShop.Controllers
{
    public class FacturasController : Controller
    {
        private FloridaBikeShopEntities db = new FloridaBikeShopEntities();

        // GET: Facturas
        public ActionResult Index()
        {
            var factura = db.Factura.Include(f => f.Servicio);
            return View(factura.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.fk_servicio = new SelectList(db.Servicio, "ID", "tipo_servicio");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,fk_servicio,valor,fecha,cliente_propietario,tecnico,bicicleta,detalles")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_servicio = new SelectList(db.Servicio, "ID", "tipo_servicio", factura.fk_servicio);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_servicio = new SelectList(db.Servicio, "ID", "tipo_servicio", factura.fk_servicio);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,fk_servicio,valor,fecha,cliente_propietario,tecnico,bicicleta,detalles")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_servicio = new SelectList(db.Servicio, "ID", "tipo_servicio", factura.fk_servicio);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Factura factura = db.Factura.Find(id);
            db.Factura.Remove(factura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
