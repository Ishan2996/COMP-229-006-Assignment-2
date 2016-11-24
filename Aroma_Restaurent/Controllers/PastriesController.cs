using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aroma_Restaurent.Models;

namespace Aroma_Restaurent.Controllers
{
    public class PastriesController : Controller
    {
        private AromaContext db = new AromaContext();

        // GET: Pastries
        public ActionResult Index()
        {
            return View(db.Pastries.ToList());
        }

        // GET: Pastries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastry pastry = db.Pastries.Find(id);
            if (pastry == null)
            {
                return HttpNotFound();
            }
            return View(pastry);
        }

        // GET: Pastries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pastries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Item,Description,Price")] Pastry pastry)
        {
            if (ModelState.IsValid)
            {
                db.Pastries.Add(pastry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pastry);
        }

        // GET: Pastries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastry pastry = db.Pastries.Find(id);
            if (pastry == null)
            {
                return HttpNotFound();
            }
            return View(pastry);
        }

        // POST: Pastries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Item,Description,Price")] Pastry pastry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pastry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pastry);
        }

        // GET: Pastries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastry pastry = db.Pastries.Find(id);
            if (pastry == null)
            {
                return HttpNotFound();
            }
            return View(pastry);
        }

        // POST: Pastries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pastry pastry = db.Pastries.Find(id);
            db.Pastries.Remove(pastry);
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
