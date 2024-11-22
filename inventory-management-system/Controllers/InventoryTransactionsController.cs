using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using inventory_management_system.Models;

namespace inventory_management_system.Controllers
{
    public class InventoryTransactionsController : Controller
    {
        private Entities db = new Entities();

        // GET: InventoryTransactions
        public ActionResult Index()
        {
            var inventoryTransactions = db.InventoryTransactions.Include(i => i.Product);
            return View(inventoryTransactions.ToList());
        }

        // GET: InventoryTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTransaction inventoryTransaction = db.InventoryTransactions.Find(id);
            if (inventoryTransaction == null)
            {
                return HttpNotFound();
            }
            return View(inventoryTransaction);
        }

        // GET: InventoryTransactions/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            return View();
        }

        // POST: InventoryTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,ProductID,ReferenceID,ReferenceType,Quantity,TransactionType,CreatedAt,UpdatedAt")] InventoryTransaction inventoryTransaction)
        {
            if (ModelState.IsValid)
            {
                db.InventoryTransactions.Add(inventoryTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", inventoryTransaction.ProductID);
            return View(inventoryTransaction);
        }

        // GET: InventoryTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTransaction inventoryTransaction = db.InventoryTransactions.Find(id);
            if (inventoryTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", inventoryTransaction.ProductID);
            return View(inventoryTransaction);
        }

        // POST: InventoryTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,ProductID,ReferenceID,ReferenceType,Quantity,TransactionType,CreatedAt,UpdatedAt")] InventoryTransaction inventoryTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", inventoryTransaction.ProductID);
            return View(inventoryTransaction);
        }

        // GET: InventoryTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTransaction inventoryTransaction = db.InventoryTransactions.Find(id);
            if (inventoryTransaction == null)
            {
                return HttpNotFound();
            }
            return View(inventoryTransaction);
        }

        // POST: InventoryTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryTransaction inventoryTransaction = db.InventoryTransactions.Find(id);
            db.InventoryTransactions.Remove(inventoryTransaction);
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
