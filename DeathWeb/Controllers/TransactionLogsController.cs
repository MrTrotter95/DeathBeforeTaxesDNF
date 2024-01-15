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
    public class TransactionLogsController : Controller
    {
        private DeathDataEntities db = new DeathDataEntities();

        // GET: TransactionLogs
        public ActionResult Index()
        {
            var transactionLogs = db.TransactionLogs.Include(t => t.Account).Include(t => t.TransactionType);
            return View(transactionLogs.ToList());
        }

        // GET: TransactionLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionLog transactionLog = db.TransactionLogs.Find(id);
            if (transactionLog == null)
            {
                return HttpNotFound();
            }
            return View(transactionLog);
        }

        // GET: TransactionLogs/Create
        public ActionResult Create()
        {
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name");
            ViewBag.FK_TransactionTypeID = new SelectList(db.TransactionTypes, "ID", "Name");
            return View();
        }

        // POST: TransactionLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_AccountID,FK_TransactionTypeID,TransactionDate,Description,Amount,Balance")] TransactionLog transactionLog)
        {
            if (ModelState.IsValid)
            {
                db.TransactionLogs.Add(transactionLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", transactionLog.FK_AccountID);
            ViewBag.FK_TransactionTypeID = new SelectList(db.TransactionTypes, "ID", "Name", transactionLog.FK_TransactionTypeID);
            return View(transactionLog);
        }

        // GET: TransactionLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionLog transactionLog = db.TransactionLogs.Find(id);
            if (transactionLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", transactionLog.FK_AccountID);
            ViewBag.FK_TransactionTypeID = new SelectList(db.TransactionTypes, "ID", "Name", transactionLog.FK_TransactionTypeID);
            return View(transactionLog);
        }

        // POST: TransactionLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_AccountID,FK_TransactionTypeID,TransactionDate,Description,Amount,Balance")] TransactionLog transactionLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", transactionLog.FK_AccountID);
            ViewBag.FK_TransactionTypeID = new SelectList(db.TransactionTypes, "ID", "Name", transactionLog.FK_TransactionTypeID);
            return View(transactionLog);
        }

        // GET: TransactionLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionLog transactionLog = db.TransactionLogs.Find(id);
            if (transactionLog == null)
            {
                return HttpNotFound();
            }
            return View(transactionLog);
        }

        // POST: TransactionLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionLog transactionLog = db.TransactionLogs.Find(id);
            db.TransactionLogs.Remove(transactionLog);
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
