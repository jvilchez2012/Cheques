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
    public class ConceptoPagoesController : Controller
    {
        private checksDBEntities db = new checksDBEntities();

        // GET: ConceptoPagoes
        public ActionResult Index()
        {
            return View(db.ConceptoPago.ToList());
        }

        // GET: ConceptoPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConceptoPago conceptoPago = db.ConceptoPago.Find(id);
            if (conceptoPago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoPago);
        }

        // GET: ConceptoPagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConceptoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado")] ConceptoPago conceptoPago)
        {
            if (ModelState.IsValid)
            {
                db.ConceptoPago.Add(conceptoPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conceptoPago);
        }

        // GET: ConceptoPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConceptoPago conceptoPago = db.ConceptoPago.Find(id);
            if (conceptoPago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoPago);
        }

        // POST: ConceptoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado")] ConceptoPago conceptoPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conceptoPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conceptoPago);
        }

        // GET: ConceptoPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConceptoPago conceptoPago = db.ConceptoPago.Find(id);
            if (conceptoPago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoPago);
        }

        // POST: ConceptoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConceptoPago conceptoPago = db.ConceptoPago.Find(id);
            db.ConceptoPago.Remove(conceptoPago);
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
