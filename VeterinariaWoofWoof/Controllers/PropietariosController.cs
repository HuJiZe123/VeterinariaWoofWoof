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
    public class PropietariosController : Controller
    {
        /// <summary>
        /// PENDIENTES
        /// 
        /// *Validar correo, telefono
        /// 
        /// </summary>

        private BD_WoofWoofEntities2 db = new BD_WoofWoofEntities2();
        private SharedFunctions shared = new SharedFunctions();


        // GET: Propietarios
        public ActionResult Index()
        {
            return View(db.Propietarios.Where(p => p.estatus == 1).ToList());
        }

        // GET: Propietarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // GET: Propietarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propietarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre_propietario,Apellido_propietario,Correo_propietario,Descripcion_direccion,Zona_direccion,Numero_telefono,estatus")] Propietario propietario)
        {
            try {
                propietario.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Propietarios.Add(propietario);
                    db.SaveChanges();
                    shared.RegisterInBitacora(2, "Propietario");
                    return RedirectToAction("Index");
                }

                return View(propietario);
            }
            catch
            {
                return View(propietario);
            }
        }

        // GET: Propietarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: Propietarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre_propietario,Apellido_propietario,Correo_propietario,Descripcion_direccion,Zona_direccion,Numero_telefono,estatus")] Propietario propietario)
        {
            try
            {
                propietario.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Entry(propietario).State = EntityState.Modified;
                    db.SaveChanges();
                    shared.RegisterInBitacora(4,"Propietario");
                    return RedirectToAction("Index");
                }
                return View(propietario);
            }
            catch
            {
                return View(propietario);
            }
            
        }

        // GET: Propietarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propietario propietario = db.Propietarios.Find(id);
            try
            {
                propietario.estatus = 0;
                if (ModelState.IsValid)
                {
                    db.Entry(propietario).State = EntityState.Modified;
                    db.SaveChanges();
                    shared.RegisterInBitacora(3, "Propietario");
                    return RedirectToAction("Index");
                }
                return View(propietario);
            }
            catch
            {
                return View(propietario);
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
