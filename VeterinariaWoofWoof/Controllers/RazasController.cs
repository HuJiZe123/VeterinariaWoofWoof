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
    public class RazasController : Controller
    {
        private BD_WoofWoofEntities2 db = new BD_WoofWoofEntities2();
        private SharedFunctions shared = new SharedFunctions();

        // GET: Razas
        public ActionResult Index()
        {
            return View(db.Razas.Where(r => r.estatus == 1).ToList());
        }

        // GET: Razas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // GET: Razas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Razas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre_raza,estatus")] Raza raza)
        {
            try
            {
                raza.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Razas.Add(raza);
                    db.SaveChanges();
                    shared.RegisterInBitacora(2, "Raza");
                    return RedirectToAction("Index");
                }
                return View(raza);
            }
            catch
            {
                return View(raza);
            }
        }

        // GET: Razas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // POST: Razas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre_raza,estatus")] Raza raza)
        {
            try
            {
                raza.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Entry(raza).State = EntityState.Modified;
                    db.SaveChanges();
                    shared.RegisterInBitacora(4, "Raza");
                    return RedirectToAction("Index");
                }
                return View(raza);
            }
            catch
            {
                return View(raza);
            }
        }

        // GET: Razas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // POST: Razas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raza raza = db.Razas.Find(id);
            try
            {
                raza.estatus = 0;
                if (ModelState.IsValid)
                {
                    db.Entry(raza).State = EntityState.Modified;
                    db.SaveChanges();
                    shared.RegisterInBitacora(3, "Raza");
                    return RedirectToAction("Index");
                }
                return View(raza);
            }
            catch
            {
                return View(raza);
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
