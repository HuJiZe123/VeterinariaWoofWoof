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
    public class EmpleadoesController : Controller
    {
        private BD_WoofWoofEntities2 db = new BD_WoofWoofEntities2();
        private SharedFunctions globales = new SharedFunctions();

        public HomeController hc = new HomeController();


        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleadoes = db.Empleadoes.Include(e => e.Puesto).Where(e => e.estatus == 1);
            return View(empleadoes.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.Codpuesto = new SelectList(db.Puestoes.Where(p => p.estatus == 1), "id", "Nombre_puesto");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre_empleado,Apellido_empleado,Codpuesto,estatus")] Empleado empleado)
        {
            try
            {
                empleado.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Empleadoes.Add(empleado);
                    db.SaveChanges();
                    globales.RegisterInBitacora(2, "Empleado");
                    return RedirectToAction("Index");
                }

                ViewBag.Codpuesto = new SelectList(db.Puestoes, "id", "Nombre_puesto", empleado.Codpuesto);
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codpuesto = new SelectList(db.Puestoes.Where(p => p.estatus == 1), "id", "Nombre_puesto", empleado.Codpuesto);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre_empleado,Apellido_empleado,Codpuesto,estatus")] Empleado empleado)
        {
            try
            {
                empleado.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Entry(empleado).State = EntityState.Modified;
                    db.SaveChanges();
                    globales.RegisterInBitacora(4, "Empleado");
                    return RedirectToAction("Index");
                }
                ViewBag.Codpuesto = new SelectList(db.Puestoes, "id", "Nombre_puesto", empleado.Codpuesto);
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
            
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            try
            {
                empleado.estatus = 0;
                if (ModelState.IsValid)
                {
                    db.Entry(empleado).State = EntityState.Modified;
                    db.SaveChanges();
                    globales.RegisterInBitacora(3, "Empleado");
                    return RedirectToAction("Index");
                }
                ViewBag.Codpuesto = new SelectList(db.Puestoes, "id", "Nombre_puesto", empleado.Codpuesto);
                return View(empleado);
            }
            catch
            {
                return View(empleado);
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
