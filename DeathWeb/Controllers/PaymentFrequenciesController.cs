﻿using System;
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
    public class PaymentFrequenciesController : Controller
    {
        private DeathDataEntities db = new DeathDataEntities();

        // GET: PaymentFrequencies
        public ActionResult Index()
        {
            return View(db.PaymentFrequencies.ToList());
        }

        // GET: PaymentFrequencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentFrequency paymentFrequency = db.PaymentFrequencies.Find(id);
            if (paymentFrequency == null)
            {
                return HttpNotFound();
            }
            return View(paymentFrequency);
        }

        // GET: PaymentFrequencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentFrequencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] PaymentFrequency paymentFrequency)
        {
            if (ModelState.IsValid)
            {
                db.PaymentFrequencies.Add(paymentFrequency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentFrequency);
        }

        // GET: PaymentFrequencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentFrequency paymentFrequency = db.PaymentFrequencies.Find(id);
            if (paymentFrequency == null)
            {
                return HttpNotFound();
            }
            return View(paymentFrequency);
        }

        // POST: PaymentFrequencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] PaymentFrequency paymentFrequency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentFrequency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentFrequency);
        }

        // GET: PaymentFrequencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentFrequency paymentFrequency = db.PaymentFrequencies.Find(id);
            if (paymentFrequency == null)
            {
                return HttpNotFound();
            }
            return View(paymentFrequency);
        }

        // POST: PaymentFrequencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentFrequency paymentFrequency = db.PaymentFrequencies.Find(id);
            db.PaymentFrequencies.Remove(paymentFrequency);
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
