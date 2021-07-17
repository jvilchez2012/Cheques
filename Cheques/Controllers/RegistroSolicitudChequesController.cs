using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cheques;

namespace Cheques.Controllers
{
    public class RegistroSolicitudChequesController : Controller
    {
        private checksDBEntities db = new checksDBEntities();

        // GET: RegistroSolicitudCheques
        public ActionResult Index()
        {
            var registroSolicitudCheque = db.RegistroSolicitudCheque.Include(r => r.Proveedores).Include(r => r.Proveedores1);
            return View(registroSolicitudCheque.ToList());
        }

        // GET: RegistroSolicitudCheques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroSolicitudCheque registroSolicitudCheque = db.RegistroSolicitudCheque.Find(id);
            if (registroSolicitudCheque == null)
            {
                return HttpNotFound();
            }
            return View(registroSolicitudCheque);
        }

        // GET: RegistroSolicitudCheques/Create
        public ActionResult Create()
        {
            ViewBag.IDProveedor = new SelectList(db.Proveedores, "ID", "Nombre");
            ViewBag.CuentaContableProveedor = new SelectList(db.Proveedores, "ID", "Nombre");
            return View();
        }

        // POST: RegistroSolicitudCheques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroSolicitud,IDProveedor,Monto,FechaRegistro,Estado,CuentaContableProveedor,CuentaContableInterna")] RegistroSolicitudCheque registroSolicitudCheque)
        {
            if (ModelState.IsValid)
            {
                db.RegistroSolicitudCheque.Add(registroSolicitudCheque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProveedor = new SelectList(db.Proveedores, "ID", "Nombre", registroSolicitudCheque.IDProveedor);
            ViewBag.CuentaContableProveedor = new SelectList(db.Proveedores, "ID", "Nombre", registroSolicitudCheque.CuentaContableProveedor);
            return View(registroSolicitudCheque);
        }

        // GET: RegistroSolicitudCheques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroSolicitudCheque registroSolicitudCheque = db.RegistroSolicitudCheque.Find(id);
            if (registroSolicitudCheque == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProveedor = new SelectList(db.Proveedores, "ID", "Nombre", registroSolicitudCheque.IDProveedor);
            ViewBag.CuentaContableProveedor = new SelectList(db.Proveedores, "ID", "Nombre", registroSolicitudCheque.CuentaContableProveedor);
            return View(registroSolicitudCheque);
        }

        // POST: RegistroSolicitudCheques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroSolicitud,IDProveedor,Monto,FechaRegistro,Estado,CuentaContableProveedor,CuentaContableInterna")] RegistroSolicitudCheque registroSolicitudCheque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroSolicitudCheque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProveedor = new SelectList(db.Proveedores, "ID", "Nombre", registroSolicitudCheque.IDProveedor);
            ViewBag.CuentaContableProveedor = new SelectList(db.Proveedores, "ID", "Nombre", registroSolicitudCheque.CuentaContableProveedor);
            return View(registroSolicitudCheque);
        }

        // GET: RegistroSolicitudCheques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroSolicitudCheque registroSolicitudCheque = db.RegistroSolicitudCheque.Find(id);
            if (registroSolicitudCheque == null)
            {
                return HttpNotFound();
            }
            return View(registroSolicitudCheque);
        }

        // POST: RegistroSolicitudCheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroSolicitudCheque registroSolicitudCheque = db.RegistroSolicitudCheque.Find(id);
            db.RegistroSolicitudCheque.Remove(registroSolicitudCheque);
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
