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
    public class ComputadorasController : Controller
    {
        private TiendaComputadorasContext db = new TiendaComputadorasContext();

        // GET: Computadoras
        public ActionResult Index(string sortOrder, string search, int? page, string currentFilter)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            ViewBag.ApellidoSortParm = sortOrder == "Precio" ? "precio_desc" : "Precio";
            var computadoras = from s in db.Computadoras select s;
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
                computadoras = computadoras.Where(s => s.Nombre.Contains(search)||
                s.Precio.ToString().Contains(search));
            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    computadoras = computadoras.OrderByDescending(s => s.Nombre);
                    break;
                case "Precio":
                    computadoras = computadoras.OrderBy(s => s.Precio);
                    break;
                case "precio_desc":
                    computadoras = computadoras.OrderByDescending(s => s.Precio);
                    break;
                default:
                    computadoras = computadoras.OrderBy(s => s.Nombre);
                    break;
            }
            //return View(clientes.ToList());
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(computadoras.ToPagedList(pageNumber, pageSize));
           
        }

        // GET: Computadoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computadora computadora = db.Computadoras.Find(id);
            if (computadora == null)
            {
                return HttpNotFound();
            }
            return View(computadora);
        }

        // GET: Computadoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Computadoras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComputadoraID,Nombre,Precio")] Computadora computadora)
        {
            if (ModelState.IsValid)
            {
                db.Computadoras.Add(computadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(computadora);
        }

        // GET: Computadoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computadora computadora = db.Computadoras.Find(id);
            if (computadora == null)
            {
                return HttpNotFound();
            }
            return View(computadora);
        }

        // POST: Computadoras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComputadoraID,Nombre,Precio")] Computadora computadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computadora);
        }

        // GET: Computadoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computadora computadora = db.Computadoras.Find(id);
            if (computadora == null)
            {
                return HttpNotFound();
            }
            return View(computadora);
        }

        // POST: Computadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Computadora computadora = db.Computadoras.Find(id);
            db.Computadoras.Remove(computadora);
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
