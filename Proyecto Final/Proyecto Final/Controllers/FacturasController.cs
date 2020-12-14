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
    public class FacturasController : Controller
    {
        private TiendaComputadorasContext db = new TiendaComputadorasContext();

        // GET: Facturas
        public ActionResult Index(string sortOrder, string search, int? page, string currentFilter)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.FacturaSortParm = String.IsNullOrEmpty(sortOrder) ? "FacturaID_desc" : "";
            ViewBag.DescripcionSortParm = sortOrder == "Descripcion" ? "descripcion_desc" : "Descripcion";
            var facturas = from s in db.Facturas select s;
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
                facturas = facturas.Where(s => s.FacturaID.ToString().Contains(search)||
                s.Descripcion.Contains(search)
                );

            }
            switch (sortOrder)
            {
                case "FacturaID_desc":
                   facturas = facturas.OrderByDescending(s => s.FacturaID);
                    break;
                case "Descripcion":
                    facturas = facturas.OrderBy(s => s.Descripcion);
                    break;
                case "descripcion_desc":
                    facturas = facturas.OrderByDescending(s => s.Descripcion);
                    break;
                default:
                    facturas = facturas.OrderBy(s => s.FacturaID);
                    break;
            }
            //return View(clientes.ToList());
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(facturas.ToPagedList(pageNumber, pageSize));
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaID,ProductoID,ClienteID,Descripcion,Cantidad,PrecioUnitario,Total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaID,ProductoID,ClienteID,Descripcion,Cantidad,PrecioUnitario,Total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
