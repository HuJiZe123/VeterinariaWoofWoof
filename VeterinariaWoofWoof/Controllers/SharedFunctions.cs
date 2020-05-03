using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaWoofWoof.Models;

namespace VeterinariaWoofWoof.Controllers
{
    public class SharedFunctions : Controller
    {
        private BD_WoofWoofEntities2 db = new BD_WoofWoofEntities2();


        // Funcion para registrar las actividades en la bitacora
        public void RegisterInBitacora(int operation, string afectedTable)
        {
            try
            {
                Bitacora bitacora = new Bitacora();
                bitacora.Codusuario = 1;                                    //Se debe sustituir por el usuario real
                bitacora.Codoperacion = operation;
                bitacora.TablaAfectada_bitacora = afectedTable;
                bitacora.FechaHora_bitacora = DateTime.Now;
                bitacora.Usuario = db.Usuarios.Find(1);                     //Se debe sustituir por el usuario real
                bitacora.Operacion = db.Operacions.Find(operation);
                if (ModelState.IsValid)
                {
                    db.Bitacoras.Add(bitacora);
                    db.SaveChanges();
                }
            }
            catch
            {
            }
        }
    }
}