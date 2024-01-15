using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeathWeb.Models;

namespace DeathWeb.Controllers
{
    public class AutomaticPaymentLogsController : Controller
    {
        private DeathDataEntities db = new DeathDataEntities();

        // GET: AutomaticPaymentLogs
        public ActionResult Index()
        {
            var automaticPaymentLogs = db.AutomaticPaymentLogs.Include(a => a.AutomaticPayment);
            return View(automaticPaymentLogs.ToList());
        }

        // GET: AutomaticPaymentLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomaticPaymentLog automaticPaymentLog = db.AutomaticPaymentLogs.Find(id);
            if (automaticPaymentLog == null)
            {
                return HttpNotFound();
            }
            return View(automaticPaymentLog);
        }

        // GET: AutomaticPaymentLogs/Create
        public ActionResult Create()
        {
            ViewBag.FK_AutomaticPaymentID = new SelectList(db.AutomaticPayments, "ID", "Name");
            return View();
        }

        // POST: AutomaticPaymentLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_AutomaticPaymentID,TransactionDate")] AutomaticPaymentLog automaticPaymentLog)
        {
            if (ModelState.IsValid)
            {
                db.AutomaticPaymentLogs.Add(automaticPaymentLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_AutomaticPaymentID = new SelectList(db.AutomaticPayments, "ID", "Name", automaticPaymentLog.FK_AutomaticPaymentID);
            return View(automaticPaymentLog);
        }

        // GET: AutomaticPaymentLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomaticPaymentLog automaticPaymentLog = db.AutomaticPaymentLogs.Find(id);
            if (automaticPaymentLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_AutomaticPaymentID = new SelectList(db.AutomaticPayments, "ID", "Name", automaticPaymentLog.FK_AutomaticPaymentID);
            return View(automaticPaymentLog);
        }

        // POST: AutomaticPaymentLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_AutomaticPaymentID,TransactionDate")] AutomaticPaymentLog automaticPaymentLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automaticPaymentLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_AutomaticPaymentID = new SelectList(db.AutomaticPayments, "ID", "Name", automaticPaymentLog.FK_AutomaticPaymentID);
            return View(automaticPaymentLog);
        }

        // GET: AutomaticPaymentLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomaticPaymentLog automaticPaymentLog = db.AutomaticPaymentLogs.Find(id);
            if (automaticPaymentLog == null)
            {
                return HttpNotFound();
            }
            return View(automaticPaymentLog);
        }

        // POST: AutomaticPaymentLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutomaticPaymentLog automaticPaymentLog = db.AutomaticPaymentLogs.Find(id);
            db.AutomaticPaymentLogs.Remove(automaticPaymentLog);
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
