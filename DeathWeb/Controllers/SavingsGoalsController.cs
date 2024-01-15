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
    public class SavingsGoalsController : Controller
    {
        private DeathDataEntities db = new DeathDataEntities();

        // GET: SavingsGoals
        public ActionResult Index()
        {
            var savingsGoals = db.SavingsGoals.Include(s => s.Account);
            return View(savingsGoals.ToList());
        }

        // GET: SavingsGoals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsGoal savingsGoal = db.SavingsGoals.Find(id);
            if (savingsGoal == null)
            {
                return HttpNotFound();
            }
            return View(savingsGoal);
        }

        // GET: SavingsGoals/Create
        public ActionResult Create()
        {
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name");
            return View();
        }

        // POST: SavingsGoals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_AccountID,Name,CurrentTotal,GoalAmount,PurchaseDate,ActualBuyPrice")] SavingsGoal savingsGoal)
        {
            if (ModelState.IsValid)
            {
                db.SavingsGoals.Add(savingsGoal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", savingsGoal.FK_AccountID);
            return View(savingsGoal);
        }

        // GET: SavingsGoals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsGoal savingsGoal = db.SavingsGoals.Find(id);
            if (savingsGoal == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", savingsGoal.FK_AccountID);
            return View(savingsGoal);
        }

        // POST: SavingsGoals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_AccountID,Name,CurrentTotal,GoalAmount,PurchaseDate,ActualBuyPrice")] SavingsGoal savingsGoal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savingsGoal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", savingsGoal.FK_AccountID);
            return View(savingsGoal);
        }

        // GET: SavingsGoals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsGoal savingsGoal = db.SavingsGoals.Find(id);
            if (savingsGoal == null)
            {
                return HttpNotFound();
            }
            return View(savingsGoal);
        }

        // POST: SavingsGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SavingsGoal savingsGoal = db.SavingsGoals.Find(id);
            db.SavingsGoals.Remove(savingsGoal);
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
