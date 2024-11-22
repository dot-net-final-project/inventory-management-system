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
    public class PurchaseOrderItemsController : Controller
    {
        private Entities db = new Entities();

        // GET: PurchaseOrderItems
        public ActionResult Index()
        {
            var purchaseOrderItems = db.PurchaseOrderItems.Include(p => p.Product).Include(p => p.Product1).Include(p => p.PurchaseOrder).Include(p => p.PurchaseOrder1).Include(p => p.PurchaseOrder2);
            return View(purchaseOrderItems.ToList());
        }

        // GET: PurchaseOrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            if (purchaseOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderItem);
        }

        // GET: PurchaseOrderItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber");
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber");
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber");
            return View();
        }

        // POST: PurchaseOrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrderItemID,PurchaseOrderID,ProductID,Quantity,UnitPrice,TotalPrice,ReceivedQuantity,CreatedAt,UpdatedAat")] PurchaseOrderItem purchaseOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrderItems.Add(purchaseOrderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", purchaseOrderItem.ProductID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", purchaseOrderItem.ProductID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            return View(purchaseOrderItem);
        }

        // GET: PurchaseOrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            if (purchaseOrderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", purchaseOrderItem.ProductID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", purchaseOrderItem.ProductID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            return View(purchaseOrderItem);
        }

        // POST: PurchaseOrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderItemID,PurchaseOrderID,ProductID,Quantity,UnitPrice,TotalPrice,ReceivedQuantity,CreatedAt,UpdatedAat")] PurchaseOrderItem purchaseOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", purchaseOrderItem.ProductID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", purchaseOrderItem.ProductID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "OrderNumber", purchaseOrderItem.PurchaseOrderID);
            return View(purchaseOrderItem);
        }

        // GET: PurchaseOrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            if (purchaseOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderItem);
        }

        // POST: PurchaseOrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            db.PurchaseOrderItems.Remove(purchaseOrderItem);
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
