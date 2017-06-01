using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistroGastosEAN.DAL;
using RegistroGastosEAN.Models;

namespace RegistroGastosEAN.Controllers
{
    public class EntidadController : Controller
    {
        private RegistroGastosContext db = new RegistroGastosContext();

        // GET: Entidad
        public ActionResult Index()
        {
            return View(db.Entidades.ToList());
        }

        // GET: Entidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidades.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            return View(entidad);
        }

        // GET: Entidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdentificadorFiscal,RazonSocial")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                db.Entidades.Add(entidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entidad);
        }

        // GET: Entidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidades.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            return View(entidad);
        }

        // POST: Entidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdentificadorFiscal,RazonSocial")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entidad);
        }

        // GET: Entidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidades.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            return View(entidad);
        }

        // POST: Entidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entidad entidad = db.Entidades.Find(id);
            db.Entidades.Remove(entidad);
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
