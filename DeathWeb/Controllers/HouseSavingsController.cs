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
    public class HouseSavingsController : Controller
    {
        private DeathDataEntities db = new DeathDataEntities();

        // GET: HouseSavings
        public ActionResult Index()
        {
            var houseSavings = db.HouseSavings.Include(h => h.Account);
            return View(houseSavings.ToList());
        }

        // GET: HouseSavings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseSaving houseSaving = db.HouseSavings.Find(id);
            if (houseSaving == null)
            {
                return HttpNotFound();
            }
            return View(houseSaving);
        }

        // GET: HouseSavings/Create
        public ActionResult Create()
        {
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name");
            return View();
        }

        // POST: HouseSavings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_AccountID,Name,StartDate,GoalDate,Amount,GoalAmount")] HouseSaving houseSaving)
        {
            if (ModelState.IsValid)
            {
                db.HouseSavings.Add(houseSaving);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", houseSaving.FK_AccountID);
            return View(houseSaving);
        }

        // GET: HouseSavings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseSaving houseSaving = db.HouseSavings.Find(id);
            if (houseSaving == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", houseSaving.FK_AccountID);
            return View(houseSaving);
        }

        // POST: HouseSavings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_AccountID,Name,StartDate,GoalDate,Amount,GoalAmount")] HouseSaving houseSaving)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseSaving).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_AccountID = new SelectList(db.Accounts, "ID", "Name", houseSaving.FK_AccountID);
            return View(houseSaving);
        }

        // GET: HouseSavings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseSaving houseSaving = db.HouseSavings.Find(id);
            if (houseSaving == null)
            {
                return HttpNotFound();
            }
            return View(houseSaving);
        }

        // POST: HouseSavings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseSaving houseSaving = db.HouseSavings.Find(id);
            db.HouseSavings.Remove(houseSaving);
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
