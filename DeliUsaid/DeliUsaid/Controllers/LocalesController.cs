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
    public class LocalesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Locales
        public ActionResult Index()
        {
            var locales = db.Locales.Include(l => l.Usuarios);
            return View(locales.ToList());
        }

        // GET: Locales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locales locales = db.Locales.Find(id);
            if (locales == null)
            {
                return HttpNotFound();
            }
            return View(locales);
        }

        // GET: Locales/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario");
            return View();
        }

        // POST: Locales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Locales locales, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                string archivo = locales.Nombre;
                string url = "/Content/Img/" + archivo + DateTime.Now.ToString("dd-MM-yyyy") + (System.IO.Path.GetExtension(Logo.FileName));
                Logo.SaveAs(Server.MapPath(url));
                locales.Logo = url;
                db.Locales.Add(locales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", locales.IdUsuario);
            return View(locales);
        }

        // GET: Locales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locales locales = db.Locales.Find(id);
            if (locales == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", locales.IdUsuario);
            return View(locales);
        }

        // POST: Locales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLocal,Nombre,Direccion,Correo,Telefono,Logo,IdUsuario")] Locales locales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", locales.IdUsuario);
            return View(locales);
        }

        // GET: Locales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locales locales = db.Locales.Find(id);
            if (locales == null)
            {
                return HttpNotFound();
            }
            return View(locales);
        }

        // POST: Locales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locales locales = db.Locales.Find(id);
            db.Locales.Remove(locales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Local(int id)
        {
            ViewBag.id = id;
            ViewBag.limit = db.Platos.Count();
            ViewBag.platos = db.Platos.ToList();
            return View(db.Platos.ToList());
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
