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
    public class CRUDClientsController : Controller
    {
        private testdbEntities db = new testdbEntities();

        // GET: CRUDClients
        public ActionResult Index()
        {
            return View(db.tableClient.ToList());
        }

        // GET: CRUDClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableClient tableClient = db.tableClient.Find(id);
            if (tableClient == null)
            {
                return HttpNotFound();
            }
            return View(tableClient);
        }

        // GET: CRUDClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUDClients/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,prenom,email,addresse,ville,telephone")] tableClient tableClient)
        {
            if (ModelState.IsValid)
            {
                db.tableClient.Add(tableClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableClient);
        }

        // GET: CRUDClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableClient tableClient = db.tableClient.Find(id);
            if (tableClient == null)
            {
                return HttpNotFound();
            }
            return View(tableClient);
        }

        // POST: CRUDClients/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,prenom,email,addresse,ville,telephone")] tableClient tableClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableClient);
        }

        // GET: CRUDClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableClient tableClient = db.tableClient.Find(id);
            if (tableClient == null)
            {
                return HttpNotFound();
            }
            return View(tableClient);
        }

        // POST: CRUDClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tableClient tableClient = db.tableClient.Find(id);
            db.tableClient.Remove(tableClient);
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
