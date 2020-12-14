using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Proyecto_Final.DAL;
using Proyecto_Final.Models;

namespace Proyecto_Final.Controllers
{
    public class ComponentesController : Controller
    {
        private TiendaComputadorasContext db = new TiendaComputadorasContext();

        // GET: Componentes
        public ActionResult Index(string sortOrder,string search, int? page, string currentFilter)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ComponenteSortParm = String.IsNullOrEmpty(sortOrder) ? "ComponenteID_desc" : "";
            ViewBag.ComputadoraSortParm = sortOrder == "Computadora" ? "computadora_desc" : "Computadora";
            var Componentes = from s in db.Componentes select s;
            //var clientes = db.Clientes.AsEnumerable();
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            if (!String.IsNullOrEmpty(search))
            {
                Componentes = Componentes.Where(s => s.Microprocesador.Contains(search)
                ||s.PlacaMadre.Contains(search) || s.Ram.Contains(search)||
                s.TarjetaVideo.Contains(search)|| s.Gabinete.Contains(search)||
                s.ComputadoraID.ToString().Contains(search) || s.ComponentesID.ToString().Contains(search)
                || s.Almacenamiento.Contains(search));
            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    Componentes = Componentes.OrderByDescending(s => s.ComponentesID.ToString());
                    break;
                case "Precio":
                    Componentes = Componentes.OrderBy(s => s.ComputadoraID);
                    break;
                case "precio_desc":
                    Componentes = Componentes.OrderByDescending(s => s.ComputadoraID);
                    break;
                default:
                    Componentes = Componentes.OrderBy(s => s.ComponentesID.ToString());
                    break;
            }
            //return View(clientes.ToList());
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(Componentes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componentes componentes = db.Componentes.Find(id);
            if (componentes == null)
            {
                return HttpNotFound();
            }
            return View(componentes);
        }

        // GET: Componentes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Componentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComponentesID,ComputadoraID,Microprocesador,Ram,PlacaMadre,Almacenamiento,TarjetaVideo,Gabinete,FuenteDePoder")] Componentes componentes)
        {
            if (ModelState.IsValid)
            {
                db.Componentes.Add(componentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(componentes);
        }

        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componentes componentes = db.Componentes.Find(id);
            if (componentes == null)
            {
                return HttpNotFound();
            }
            return View(componentes);
        }

        // POST: Componentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComponentesID,ComputadoraID,Microprocesador,Ram,PlacaMadre,Almacenamiento,TarjetaVideo,Gabinete,FuenteDePoder")] Componentes componentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(componentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(componentes);
        }

        // GET: Componentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componentes componentes = db.Componentes.Find(id);
            if (componentes == null)
            {
                return HttpNotFound();
            }
            return View(componentes);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Componentes componentes = db.Componentes.Find(id);
            db.Componentes.Remove(componentes);
            db.SaveChanges();
            return RedirectToAction("Index");
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
