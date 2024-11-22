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
    public class SalesOrderItemsController : Controller
    {
        private Entities db = new Entities();

        // GET: SalesOrderItems
        public ActionResult Index()
        {
            var salesOrderItems = db.SalesOrderItems.Include(s => s.Product).Include(s => s.SalesOrder);
            return View(salesOrderItems.ToList());
        }

        // GET: SalesOrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrderItem salesOrderItem = db.SalesOrderItems.Find(id);
            if (salesOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(salesOrderItem);
        }

        // GET: SalesOrderItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.SalesOrderID = new SelectList(db.SalesOrders, "SalesOrderID", "OrderNumber");
            return View();
        }

        // POST: SalesOrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesOrderItemID,SalesOrderID,ProductID,Quantity,UnitPrice,TotalPrice,CreatedAt,UpdatedAt")] SalesOrderItem salesOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.SalesOrderItems.Add(salesOrderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", salesOrderItem.ProductID);
            ViewBag.SalesOrderID = new SelectList(db.SalesOrders, "SalesOrderID", "OrderNumber", salesOrderItem.SalesOrderID);
            return View(salesOrderItem);
        }

        // GET: SalesOrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrderItem salesOrderItem = db.SalesOrderItems.Find(id);
            if (salesOrderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", salesOrderItem.ProductID);
            ViewBag.SalesOrderID = new SelectList(db.SalesOrders, "SalesOrderID", "OrderNumber", salesOrderItem.SalesOrderID);
            return View(salesOrderItem);
        }

        // POST: SalesOrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesOrderItemID,SalesOrderID,ProductID,Quantity,UnitPrice,TotalPrice,CreatedAt,UpdatedAt")] SalesOrderItem salesOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesOrderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", salesOrderItem.ProductID);
            ViewBag.SalesOrderID = new SelectList(db.SalesOrders, "SalesOrderID", "OrderNumber", salesOrderItem.SalesOrderID);
            return View(salesOrderItem);
        }

        // GET: SalesOrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrderItem salesOrderItem = db.SalesOrderItems.Find(id);
            if (salesOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(salesOrderItem);
        }

        // POST: SalesOrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesOrderItem salesOrderItem = db.SalesOrderItems.Find(id);
            db.SalesOrderItems.Remove(salesOrderItem);
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
