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
    public class ServiciosController : Controller
    {
        private FloridaBikeShopEntities db = new FloridaBikeShopEntities();

        // GET: Servicios
        public ActionResult Index()
        {
            var servicio = db.Servicio.Include(s => s.Bicicleta).Include(s => s.Tecnico);
            return View(servicio.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.fk_bicicleta = new SelectList(db.Bicicleta, "ID", "tipo");
            ViewBag.fk_tecnico = new SelectList(db.Tecnico, "ID", "documento");
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,tipo_servicio,valor_servicio,fecha_servicio,fk_tecnico,fk_bicicleta")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_bicicleta = new SelectList(db.Bicicleta, "ID", "tipo", servicio.fk_bicicleta);
            ViewBag.fk_tecnico = new SelectList(db.Tecnico, "ID", "documento", servicio.fk_tecnico);
            return View(servicio);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_bicicleta = new SelectList(db.Bicicleta, "ID", "tipo", servicio.fk_bicicleta);
            ViewBag.fk_tecnico = new SelectList(db.Tecnico, "ID", "documento", servicio.fk_tecnico);
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,tipo_servicio,valor_servicio,fecha_servicio,fk_tecnico,fk_bicicleta")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_bicicleta = new SelectList(db.Bicicleta, "ID", "tipo", servicio.fk_bicicleta);
            ViewBag.fk_tecnico = new SelectList(db.Tecnico, "ID", "documento", servicio.fk_tecnico);
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Servicio servicio = db.Servicio.Find(id);
            db.Servicio.Remove(servicio);
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
