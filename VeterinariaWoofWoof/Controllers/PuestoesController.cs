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
    public class PuestoesController : Controller
    {
        private BD_WoofWoofEntities2 db = new BD_WoofWoofEntities2();
        private SharedFunctions globales = new SharedFunctions();

        // GET: Puestoes
        public ActionResult Index()
        {
            return View(db.Puestoes.Where(p => p.estatus == 1).ToList());
        }

        // GET: Puestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto puesto = db.Puestoes.Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            return View(puesto);
        }

        // GET: Puestoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre_puesto,estatus")] Puesto puesto)
        {
            try
            {
                puesto.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Puestoes.Add(puesto);
                    db.SaveChanges();
                    globales.RegisterInBitacora(2, "Puesto");
                    return RedirectToAction("Index");
                }

                return View(puesto);
            }
            catch
            {
                return View(puesto);
            }
            
        }

        // GET: Puestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto puesto = db.Puestoes.Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            return View(puesto);
        }

        // POST: Puestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre_puesto,estatus")] Puesto puesto)
        {
            try
            {
                puesto.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Entry(puesto).State = EntityState.Modified;
                    db.SaveChanges();
                    globales.RegisterInBitacora(4, "Puesto");
                    return RedirectToAction("Index");
                }
                return View(puesto);
            }
            catch
            {
                return View(puesto);
            }
            
        }

        // GET: Puestoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto puesto = db.Puestoes.Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            return View(puesto);
        }

        // POST: Puestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puesto puesto = db.Puestoes.Find(id);
            try
            {
                puesto.estatus = 0;
                if (ModelState.IsValid)
                {
                    db.Entry(puesto).State = EntityState.Modified;
                    db.SaveChanges();
                    globales.RegisterInBitacora(3, "Puesto");
                    return RedirectToAction("Index");
                }
                return View(puesto);
            }
            catch
            {
                return View(puesto);
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
