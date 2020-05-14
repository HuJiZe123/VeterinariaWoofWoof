using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaWoofWoof.Models;
using VeterinariaWoofWoof.Controllers;

namespace VeterinariaWoofWoof.Controllers
{
    public class ServiciosController : Controller
    {
        /***********************          PENDIENTES         *********************
         * Cambiar el textbox del precio por uno que solo acepte numeros
         * 
         * ***********************************************************************/

        private BD_WoofWoofEntities2 db = new BD_WoofWoofEntities2();
        private SharedFunctions globales = new SharedFunctions();

        // GET: Servicios
        public ActionResult Index()
        {
            return View(db.Servicios.Where(s => s.estatus == 1).ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicios.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre_servicio,Precio_servicio,estatus")] Servicio servicio)
        {
            try
            {
                servicio.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Servicios.Add(servicio);
                    db.SaveChanges();
                    var dat = this;
                    globales.RegisterInBitacora(2, "Servicio");
                    return RedirectToAction("Index");
                }
                return View(servicio);
            }
            catch
            {
                return View(servicio);
            }
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicios.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre_servicio,Precio_servicio,estatus")] Servicio servicio)
        {
            try
            {
                servicio.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Entry(servicio).State = EntityState.Modified;
                    db.SaveChanges();
                    globales.RegisterInBitacora(4, "Servicios");
                    return RedirectToAction("Index");
                }
                return View(servicio);
            }
            catch
            {
                return View(servicio);
            }
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicios.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicio servicio = db.Servicios.Find(id);
            try
            {
                servicio.estatus = 0;
                if (ModelState.IsValid)
                {
                    db.Entry(servicio).State = EntityState.Modified;
                    db.SaveChanges();
                    globales.RegisterInBitacora(3, "Servicios");
                    return RedirectToAction("Index");
                }
                return View(servicio);
            }
            catch
            {
                return View(servicio);
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
