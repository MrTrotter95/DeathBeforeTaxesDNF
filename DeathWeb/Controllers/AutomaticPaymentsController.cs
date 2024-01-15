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
    public class AutomaticPaymentsController : Controller
    {
        private DeathDataEntities db = new DeathDataEntities();

        // GET: AutomaticPayments
        public ActionResult Index()
        {
            var automaticPayments = db.AutomaticPayments.Include(a => a.Account).Include(a => a.TransactionCategory).Include(a => a.PaymentFrequency);
            return View(automaticPayments.ToList());
        }

        // GET: AutomaticPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomaticPayment automaticPayment = db.AutomaticPayments.Find(id);
            if (automaticPayment == null)
            {
                return HttpNotFound();
            }
            return View(automaticPayment);
        }

        // GET: AutomaticPayments/Create
        public ActionResult Create()
        {
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name");
            ViewBag.FK_CategoryID = new SelectList(db.TransactionCategories, "ID", "Name");
            ViewBag.FK_FrequencyID = new SelectList(db.PaymentFrequencies, "ID", "Name");
            return View();
        }

        // POST: AutomaticPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_AccountID,FK_FrequencyID,FK_CategoryID,Name,Amount,StartDate,EndDate")] AutomaticPayment automaticPayment)
        {
            if (ModelState.IsValid)
            {
                db.AutomaticPayments.Add(automaticPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", automaticPayment.FK_AccountID);
            ViewBag.FK_CategoryID = new SelectList(db.TransactionCategories, "ID", "Name", automaticPayment.FK_CategoryID);
            ViewBag.FK_FrequencyID = new SelectList(db.PaymentFrequencies, "ID", "Name", automaticPayment.FK_FrequencyID);
            return View(automaticPayment);
        }

        // GET: AutomaticPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomaticPayment automaticPayment = db.AutomaticPayments.Find(id);
            if (automaticPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", automaticPayment.FK_AccountID);
            ViewBag.FK_CategoryID = new SelectList(db.TransactionCategories, "ID", "Name", automaticPayment.FK_CategoryID);
            ViewBag.FK_FrequencyID = new SelectList(db.PaymentFrequencies, "ID", "Name", automaticPayment.FK_FrequencyID);
            return View(automaticPayment);
        }

        // POST: AutomaticPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_AccountID,FK_FrequencyID,FK_CategoryID,Name,Amount,StartDate,EndDate")] AutomaticPayment automaticPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automaticPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", automaticPayment.FK_AccountID);
            ViewBag.FK_CategoryID = new SelectList(db.TransactionCategories, "ID", "Name", automaticPayment.FK_CategoryID);
            ViewBag.FK_FrequencyID = new SelectList(db.PaymentFrequencies, "ID", "Name", automaticPayment.FK_FrequencyID);
            return View(automaticPayment);
        }

        // GET: AutomaticPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomaticPayment automaticPayment = db.AutomaticPayments.Find(id);
            if (automaticPayment == null)
            {
                return HttpNotFound();
            }
            return View(automaticPayment);
        }

        // POST: AutomaticPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutomaticPayment automaticPayment = db.AutomaticPayments.Find(id);
            db.AutomaticPayments.Remove(automaticPayment);
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
