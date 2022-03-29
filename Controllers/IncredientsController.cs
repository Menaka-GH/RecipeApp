using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeApp;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    public class IncredientsController : Controller
    {
        private RecipeContext db = new RecipeContext();

        // GET: Incredients
        public ActionResult Index()
        {
            return View(db.Incredients.ToList());
        }

        // GET: Incredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incredient incredient = db.Incredients.Find(id);
            if (incredient == null)
            {
                return HttpNotFound();
            }
            return View(incredient);
        }

        // GET: Incredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncredientId,IncredientName")] Incredient incredient)
        {
            if (ModelState.IsValid)
            {
                db.Incredients.Add(incredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incredient);
        }

        // GET: Incredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incredient incredient = db.Incredients.Find(id);
            if (incredient == null)
            {
                return HttpNotFound();
            }
            return View(incredient);
        }

        // POST: Incredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncredientId,IncredientName")] Incredient incredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incredient);
        }

        // GET: Incredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incredient incredient = db.Incredients.Find(id);
            if (incredient == null)
            {
                return HttpNotFound();
            }
            return View(incredient);
        }

        // POST: Incredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incredient incredient = db.Incredients.Find(id);
            db.Incredients.Remove(incredient);
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
