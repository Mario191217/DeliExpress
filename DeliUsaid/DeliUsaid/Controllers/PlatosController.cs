using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliUsaid.Models;

namespace DeliUsaid.Controllers
{
    public class PlatosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Platos
        public ActionResult Index()
        {
            var platos = db.Platos.Include(p => p.Locales);
            return View(platos.ToList());
        }

        // GET: Platos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platos platos = db.Platos.Find(id);
            if (platos == null)
            {
                return HttpNotFound();
            }
            return View(platos);
        }

        // GET: Platos/Create
        public ActionResult Create()
        {
            ViewBag.IdLocal = new SelectList(db.Locales, "IdLocal", "Nombre");
            return View();
        }

        // POST: Platos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlato,NombrePlato,Precio,Descripcion,Foto1,Foto2,Foto3,IdLocal")] Platos platos)
        {
            if (ModelState.IsValid)
            {
                db.Platos.Add(platos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLocal = new SelectList(db.Locales, "IdLocal", "Nombre", platos.IdLocal);
            return View(platos);
        }

        // GET: Platos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platos platos = db.Platos.Find(id);
            if (platos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLocal = new SelectList(db.Locales, "IdLocal", "Nombre", platos.IdLocal);
            return View(platos);
        }

        // POST: Platos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlato,NombrePlato,Precio,Descripcion,Foto1,Foto2,Foto3,IdLocal")] Platos platos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLocal = new SelectList(db.Locales, "IdLocal", "Nombre", platos.IdLocal);
            return View(platos);
        }

        // GET: Platos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platos platos = db.Platos.Find(id);
            if (platos == null)
            {
                return HttpNotFound();
            }
            return View(platos);
        }

        // POST: Platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Platos platos = db.Platos.Find(id);
            db.Platos.Remove(platos);
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
