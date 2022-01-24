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
    public class OrderController : Controller
    {
        private testdbEntities db = new testdbEntities();

        // GET: Order
        public ActionResult Index()
        {
            var tableCommande = db.tableCommande.Include(t => t.tableClient).Include(t => t.tableTshirt);
            return View(tableCommande.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableCommande tableCommande = db.tableCommande.Find(id);
            if (tableCommande == null)
            {
                return HttpNotFound();
            }
            return View(tableCommande);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.IdCmdClt = new SelectList(db.tableClient, "id", "nom");
            ViewBag.IdCmdTshirt = new SelectList(db.tableTshirt, "IdTshirt", "taille");
            return View();
        }

        // POST: Order/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCmd,IdCmdTshirt,etat,IdCmdClt")] tableCommande tableCommande)
        {
            if (ModelState.IsValid)
            {
                db.tableCommande.Add(tableCommande);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }

            ViewBag.IdCmdClt = new SelectList(db.tableClient, "id", "nom", tableCommande.IdCmdClt);
            ViewBag.IdCmdTshirt = new SelectList(db.tableTshirt, "IdTshirt", "taille", tableCommande.IdCmdTshirt);
            return View();
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableCommande tableCommande = db.tableCommande.Find(id);
            if (tableCommande == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCmdClt = new SelectList(db.tableClient, "id", "nom", tableCommande.IdCmdClt);
            ViewBag.IdCmdTshirt = new SelectList(db.tableTshirt, "IdTshirt", "taille", tableCommande.IdCmdTshirt);
            return View(tableCommande);
        }

        // POST: Order/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCmd,IdCmdTshirt,etat,IdCmdClt")] tableCommande tableCommande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableCommande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCmdClt = new SelectList(db.tableClient, "id", "nom", tableCommande.IdCmdClt);
            ViewBag.IdCmdTshirt = new SelectList(db.tableTshirt, "IdTshirt", "taille", tableCommande.IdCmdTshirt);
            return View(tableCommande);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableCommande tableCommande = db.tableCommande.Find(id);
            if (tableCommande == null)
            {
                return HttpNotFound();
            }
            return View(tableCommande);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tableCommande tableCommande = db.tableCommande.Find(id);
            db.tableCommande.Remove(tableCommande);
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
