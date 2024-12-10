using DocumentFormat.OpenXml.Spreadsheet;
using ExamenParcialLozano.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenParcialLozano.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult Index()
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                return View(contexto.Equipos.ToList());
            }
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int id)
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                return View(contexto.Equipos.Where(x => x.ID_Equipo == id).FirstOrDefault());
            }
                
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                return View();
            }
        }

        // POST: Equipo/Create
        [HttpPost]
        public ActionResult Create(Equipos EquiposArray)
        {
            try
            {
                // TODO: Add insert logic here
                using (JugadoresEntity contexto = new JugadoresEntity())
                {
                    contexto.Equipos.Add(EquiposArray);
                    contexto.SaveChanges();
                }
                return RedirectToAction("/Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int id)
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                Equipos equipo = contexto.Equipos.Find(id); // Busca el equipo por ID

                if (equipo == null)
                {
                    return HttpNotFound(); // Devuelve un 404 si no se encuentra el equipo
                }

                return View(equipo);
            }
        }

        // POST: Equipo/Edit/5
        [HttpPost]
        public ActionResult Edit(Equipos equipo) // Recibe el objeto Equipos directamente
        {
            try
            {
                using (JugadoresEntity contexto = new JugadoresEntity())
                {
                    // Adjunta el equipo al contexto si no se está rastreando
                    contexto.Equipos.Attach(equipo);

                    // Marca el equipo como modificado
                    var entry = contexto.Entry(equipo);
                    entry.State = EntityState.Modified;

                    contexto.SaveChanges();
                }
                return RedirectToAction("Index"); // Redirige a la acción Index del mismo controlador
            }
            catch (Exception ex)
            {
                // Registra la excepción para depuración
                // Logger.Error(ex); // Reemplaza Logger con tu mecanismo de registro

                ModelState.AddModelError("", "Error al actualizar el equipo. Por favor, inténtalo de nuevo."); // Agrega un mensaje de error al ModelState
                return View(equipo); // Vuelve a mostrar la vista con el mensaje de error
            }
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int id)
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                
                return View(contexto.Equipos.Where(x => x.ID_Equipo == id).FirstOrDefault());
            }
 
        }

        // POST: Equipo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (JugadoresEntity contexto = new JugadoresEntity())
                {
                    Equipos objEquipos = contexto.Equipos.Where(x => x.ID_Equipo == id).FirstOrDefault();
                    contexto.Equipos.Remove(objEquipos);
                    contexto.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
