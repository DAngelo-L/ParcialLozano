using ExamenParcialLozano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenParcialLozano.Models;
using System.Data;

namespace ExamenParcialLozano.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
            using (JugadoresEntity contexto=new JugadoresEntity())
            {
                return View(contexto.Jugadores.ToList());
            }
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                return View(contexto.Jugadores.Where(x=> x.ID_Jugador==id).FirstOrDefault());
            }
                
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                return View();
            }
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create(Jugadores jugadoresArray)
        {
            try
            {
                // TODO: Add insert logic here
                using (JugadoresEntity contexto = new JugadoresEntity())
                {
                    contexto.Jugadores.Add(jugadoresArray);
                    contexto.SaveChanges();
                }
                return RedirectToAction("/Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                return View(contexto.Jugadores.Where(x => x.ID_Jugador == id).FirstOrDefault());
            }
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Jugadores jugadoresArray)
        {
            try
            {
                // TODO: Add update logic here
                using (JugadoresEntity contexto = new JugadoresEntity())
                {
                    contexto.Entry(jugadoresArray).State=EntityState.Modified;
                    contexto.SaveChanges();
                }
                    return RedirectToAction("/");
            }
            catch
            {
                return View("/");
            }
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            using (JugadoresEntity contexto = new JugadoresEntity())
            {
                
                return View(contexto.Jugadores.Where(x => x.ID_Jugador == id).FirstOrDefault());
            }
               
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (JugadoresEntity contexto = new JugadoresEntity())
                {
                    Jugadores objJugadores = contexto.Jugadores.Where(x => x.ID_Jugador == id).FirstOrDefault();
                    contexto.Jugadores.Remove(objJugadores);
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
