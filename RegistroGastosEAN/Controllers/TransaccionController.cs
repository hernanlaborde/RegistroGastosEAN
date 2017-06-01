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
    public class TransaccionController : Controller
    {
        private RegistroGastosContext db = new RegistroGastosContext();

        // GET: Transaccion
        public ActionResult Index()
        {
            var transacciones = db.Transacciones.Include(t => t.Entidades).Include(t => t.Responsables);
            return View(transacciones.ToList());
        }

        // GET: Transaccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccion/Create
        public ActionResult Create()
        {
            ViewBag.EntidadID = new SelectList(db.Entidades, "ID", "IdentificadorFiscal");
            ViewBag.ResponsableID = new SelectList(db.Responsables, "ID", "NumeroIdentificacion");
            return View();
        }

        // POST: Transaccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Fecha,Monto,ResponsableID,EntidadID")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntidadID = new SelectList(db.Entidades, "ID", "IdentificadorFiscal", transaccion.EntidadID);
            ViewBag.ResponsableID = new SelectList(db.Responsables, "ID", "NumeroIdentificacion", transaccion.ResponsableID);
            return View(transaccion);
        }

        // GET: Transaccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntidadID = new SelectList(db.Entidades, "ID", "IdentificadorFiscal", transaccion.EntidadID);
            ViewBag.ResponsableID = new SelectList(db.Responsables, "ID", "NumeroIdentificacion", transaccion.ResponsableID);
            return View(transaccion);
        }

        // POST: Transaccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Fecha,Monto,ResponsableID,EntidadID")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntidadID = new SelectList(db.Entidades, "ID", "IdentificadorFiscal", transaccion.EntidadID);
            ViewBag.ResponsableID = new SelectList(db.Responsables, "ID", "NumeroIdentificacion", transaccion.ResponsableID);
            return View(transaccion);
        }

        // GET: Transaccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transacciones.Find(id);
            db.Transacciones.Remove(transaccion);
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
