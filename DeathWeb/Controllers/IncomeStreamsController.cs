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
    public class IncomeStreamsController : Controller
    {
        private DeathDataEntities db = new DeathDataEntities();

        // GET: IncomeStreams
        public ActionResult Index()
        {
            var incomeStreams = db.IncomeStreams.Include(i => i.PaymentFrequency);
            return View(incomeStreams.ToList());
        }

        // GET: IncomeStreams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeStream incomeStream = db.IncomeStreams.Find(id);
            if (incomeStream == null)
            {
                return HttpNotFound();
            }
            return View(incomeStream);
        }

        // GET: IncomeStreams/Create
        public ActionResult Create()
        {
            ViewBag.FK_FrequencyID = new SelectList(db.PaymentFrequencies, "ID", "Name");
            return View();
        }

        // POST: IncomeStreams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_FrequencyID,Person,Amount,StartDate,EndDate")] IncomeStream incomeStream)
        {
            if (ModelState.IsValid)
            {
                db.IncomeStreams.Add(incomeStream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_FrequencyID = new SelectList(db.PaymentFrequencies, "ID", "Name", incomeStream.FK_FrequencyID);
            return View(incomeStream);
        }

        // GET: IncomeStreams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeStream incomeStream = db.IncomeStreams.Find(id);
            if (incomeStream == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_FrequencyID = new SelectList(db.PaymentFrequencies, "ID", "Name", incomeStream.FK_FrequencyID);
            return View(incomeStream);
        }

        // POST: IncomeStreams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_FrequencyID,Person,Amount,StartDate,EndDate")] IncomeStream incomeStream)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomeStream).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_FrequencyID = new SelectList(db.PaymentFrequencies, "ID", "Name", incomeStream.FK_FrequencyID);
            return View(incomeStream);
        }

        // GET: IncomeStreams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeStream incomeStream = db.IncomeStreams.Find(id);
            if (incomeStream == null)
            {
                return HttpNotFound();
            }
            return View(incomeStream);
        }

        // POST: IncomeStreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomeStream incomeStream = db.IncomeStreams.Find(id);
            db.IncomeStreams.Remove(incomeStream);
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
