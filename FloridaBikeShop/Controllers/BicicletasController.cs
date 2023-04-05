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
    public class BicicletasController : Controller
    {
        private FloridaBikeShopEntities db = new FloridaBikeShopEntities();

        // GET: Bicicletas
        public ActionResult Index()
        {
            var bicicleta = db.Bicicleta.Include(b => b.Propietario);
            return View(bicicleta.ToList());
        }

        // GET: Bicicletas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // GET: Bicicletas/Create
        public ActionResult Create()
        {
            ViewBag.fk_propietario = new SelectList(db.Propietario, "ID", "documento");
            return View();
        }

        // POST: Bicicletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,tipo,marca,valor_bicicleta,fecha_compra,fk_propietario")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                db.Bicicleta.Add(bicicleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_propietario = new SelectList(db.Propietario, "ID", "documento", bicicleta.fk_propietario);
            return View(bicicleta);
        }

        // GET: Bicicletas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_propietario = new SelectList(db.Propietario, "ID", "documento", bicicleta.fk_propietario);
            return View(bicicleta);
        }

        // POST: Bicicletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,tipo,marca,valor_bicicleta,fecha_compra,fk_propietario")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicicleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_propietario = new SelectList(db.Propietario, "ID", "documento", bicicleta.fk_propietario);
            return View(bicicleta);
        }

        // GET: Bicicletas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            db.Bicicleta.Remove(bicicleta);
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
