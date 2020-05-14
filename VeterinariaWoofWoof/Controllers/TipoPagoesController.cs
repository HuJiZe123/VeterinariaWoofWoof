using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaWoofWoof.Models;

namespace VeterinariaWoofWoof.Controllers
{
    public class TipoPagoesController : Controller
    {
        private BD_WoofWoofEntities2 db = new BD_WoofWoofEntities2();
        private SharedFunctions globales = new SharedFunctions();

        // GET: TipoPagoes
        public ActionResult Index()
        {
            return View(db.TipoPagoes.Where(t => t.estatus == 1).ToList());
        }

        // GET: TipoPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // GET: TipoPagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Tipo_pago,estatus")] TipoPago tipoPago)
        {
            try
            {
                tipoPago.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.TipoPagoes.Add(tipoPago);
                    db.SaveChanges();
                    globales.RegisterInBitacora(2,"Tipo Pago");
                    return RedirectToAction("Index");
                }

                return View(tipoPago);
            }
            catch
            {
                return View(tipoPago);
            }

        }

        // GET: TipoPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // POST: TipoPagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Tipo_pago,estatus")] TipoPago tipoPago)
        {
            try
            {
                tipoPago.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Entry(tipoPago).State = EntityState.Modified;
                    db.SaveChanges();
                    globales.RegisterInBitacora(4, "Tipo Pago");
                    return RedirectToAction("Index");
                }
                return View(tipoPago);
            }
            catch {
                return View(tipoPago);
            }
            
        }

        // GET: TipoPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // POST: TipoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            try
            {
                tipoPago.estatus = 0;
                if (ModelState.IsValid)
                {
                    db.Entry(tipoPago).State = EntityState.Modified;
                    db.SaveChanges();
                    globales.RegisterInBitacora(3, "Tipo Pago");
                    return RedirectToAction("Index");
                }
                return View(tipoPago);
            }
            catch
            {
                return View(tipoPago);
            }
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
