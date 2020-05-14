using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaWoofWoof.Models;

namespace VeterinariaWoofWoof.Controllers
{
    public class ClientesController : Controller
    {
        /// <summary>
        /// PENDIENTES
        /// 
        /// * Concatenar nombres y apellido del propietario
        /// 
        /// </summary>

        private BD_WoofWoofEntities2 db = new BD_WoofWoofEntities2();
        private SharedFunctions shared = new SharedFunctions();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Propietario).Include(c => c.Raza).Where(c => c.estatus == 1);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Codpropietario = new SelectList(db.Propietarios.Where(p => p.estatus == 1), "id", "Nombre_propietario");
            ViewBag.Codraza = new SelectList(db.Razas.Where(r => r.estatus == 1), "id", "Nombre_raza");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre_cliente,Codraza,Codpropietario,estatus,ImgPath_cliente")] Cliente cliente)
        {
            try
            {
                cliente.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    shared.RegisterInBitacora(2, "Cliente");
                    return RedirectToAction("Index");
                }
                ViewBag.Codpropietario = new SelectList(db.Propietarios.Where(p => p.estatus == 1), "id", "Nombre_propietario");
                ViewBag.Codraza = new SelectList(db.Razas.Where(r => r.estatus == 1), "id", "Nombre_raza");
                return View(cliente);
            }
            catch
            {
                ViewBag.Codpropietario = new SelectList(db.Propietarios.Where(p => p.estatus == 1), "id", "Nombre_propietario");
                ViewBag.Codraza = new SelectList(db.Razas.Where(r => r.estatus == 1), "id", "Nombre_raza");
                return View(cliente);
            }
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SaveImages( listing)
        {
            if(file.ContentLength > 0)
            {
                string filePath = Path.Combine(HttpContext.Server.MapPath("~/Img/"),
                    Path.GetFileName(file.FileName));
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codpropietario = new SelectList(db.Propietarios.Where(p => p.estatus == 1), "id", "Nombre_propietario");
            ViewBag.Codraza = new SelectList(db.Razas.Where(r => r.estatus == 1), "id", "Nombre_raza");
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre_cliente,Codraza,Codpropietario,estatus,ImgPath_cliente")] Cliente cliente)
        {
            try
            {
                cliente.estatus = 1;
                if (ModelState.IsValid)
                {
                    db.Entry(cliente).State = EntityState.Modified;
                    db.SaveChanges();
                    shared.RegisterInBitacora(4, "Cliente");
                    return RedirectToAction("Index");
                }
                ViewBag.Codpropietario = new SelectList(db.Propietarios.Where(p => p.estatus == 1), "id", "Nombre_propietario");
                ViewBag.Codraza = new SelectList(db.Razas.Where(r => r.estatus == 1), "id", "Nombre_raza");
                return View(cliente);
            }
            catch
            {
                ViewBag.Codpropietario = new SelectList(db.Propietarios.Where(p => p.estatus == 1), "id", "Nombre_propietario");
                ViewBag.Codraza = new SelectList(db.Razas.Where(r => r.estatus == 1), "id", "Nombre_raza");
                return View(cliente);
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            try
            {
                cliente.estatus = 0;
                if (ModelState.IsValid)
                {
                    db.Entry(cliente).State = EntityState.Modified;
                    db.SaveChanges();
                    shared.RegisterInBitacora(3, "Cliente");
                    return RedirectToAction("Index");
                }
                ViewBag.Codpropietario = new SelectList(db.Propietarios.Where(p => p.estatus == 1), "id", "Nombre_propietario");
                ViewBag.Codraza = new SelectList(db.Razas.Where(r => r.estatus == 1), "id", "Nombre_raza");
                return View(cliente);
            }
            catch
            {
                ViewBag.Codpropietario = new SelectList(db.Propietarios.Where(p => p.estatus == 1), "id", "Nombre_propietario");
                ViewBag.Codraza = new SelectList(db.Razas.Where(r => r.estatus == 1), "id", "Nombre_raza");
                return View(cliente);
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
