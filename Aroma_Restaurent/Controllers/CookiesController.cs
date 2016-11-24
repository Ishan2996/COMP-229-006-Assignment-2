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
    public class CookiesController : Controller
    {
        private AromaContext db = new AromaContext();

        // GET: Cookies
        public ActionResult Index()
        {
            return View(db.Cookies.ToList());
        }

        // GET: Cookies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooky cooky = db.Cookies.Find(id);
            if (cooky == null)
            {
                return HttpNotFound();
            }
            return View(cooky);
        }

        // GET: Cookies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cookies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Item,Description,Price")] Cooky cooky)
        {
            if (ModelState.IsValid)
            {
                db.Cookies.Add(cooky);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cooky);
        }

        // GET: Cookies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooky cooky = db.Cookies.Find(id);
            if (cooky == null)
            {
                return HttpNotFound();
            }
            return View(cooky);
        }

        // POST: Cookies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Item,Description,Price")] Cooky cooky)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cooky).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cooky);
        }

        // GET: Cookies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooky cooky = db.Cookies.Find(id);
            if (cooky == null)
            {
                return HttpNotFound();
            }
            return View(cooky);
        }

        // POST: Cookies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cooky cooky = db.Cookies.Find(id);
            db.Cookies.Remove(cooky);
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
