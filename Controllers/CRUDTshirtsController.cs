using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tshirt.Context;

namespace Tshirt.Controllers
{
    public class CRUDTshirtsController : Controller
    {
        private testdbEntities db = new testdbEntities();

        // GET: CRUDTshirts
        public ActionResult Index()
        {
            return View(db.tableTshirt.ToList());
        }

        // GET: CRUDTshirts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableTshirt tableTshirt = db.tableTshirt.Find(id);
            if (tableTshirt == null)
            {
                return HttpNotFound();
            }
            return View(tableTshirt);
        }

        // GET: CRUDTshirts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUDTshirts/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTshirt,taille,couleur,prix,img")] tableTshirt tableTshirt)
        {
            if (ModelState.IsValid)
            {
                db.tableTshirt.Add(tableTshirt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableTshirt);
        }

        // GET: CRUDTshirts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableTshirt tableTshirt = db.tableTshirt.Find(id);
            if (tableTshirt == null)
            {
                return HttpNotFound();
            }
            return View(tableTshirt);
        }

        // POST: CRUDTshirts/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTshirt,taille,couleur,prix,img")] tableTshirt tableTshirt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableTshirt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableTshirt);
        }

        // GET: CRUDTshirts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableTshirt tableTshirt = db.tableTshirt.Find(id);
            if (tableTshirt == null)
            {
                return HttpNotFound();
            }
            return View(tableTshirt);
        }

        // POST: CRUDTshirts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tableTshirt tableTshirt = db.tableTshirt.Find(id);
            db.tableTshirt.Remove(tableTshirt);
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
