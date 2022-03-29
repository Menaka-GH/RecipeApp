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
    public class RecipeStepsController : Controller
    {
        private RecipeContext db = new RecipeContext();

        // GET: RecipeSteps
        public ActionResult Index()
        {
            var recipesteps = db.Recipesteps.Include(r => r.Recipe);
            return View(recipesteps.ToList());
        }

        // GET: RecipeSteps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeStep recipeStep = db.Recipesteps.Find(id);
            if (recipeStep == null)
            {
                return HttpNotFound();
            }
            return View(recipeStep);
        }

        // GET: RecipeSteps/Create
        public ActionResult Create()
        {
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "RecipeName");
            return View();
        }

        // POST: RecipeSteps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Instructions,PrepTime,CookTime,RecipeId")] RecipeStep recipeStep)
        {
            if (ModelState.IsValid)
            {
                db.Recipesteps.Add(recipeStep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "RecipeName", recipeStep.RecipeId);
            return View(recipeStep);
        }

        // GET: RecipeSteps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeStep recipeStep = db.Recipesteps.Find(id);
            if (recipeStep == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "RecipeName", recipeStep.RecipeId);
            return View(recipeStep);
        }

        // POST: RecipeSteps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Instructions,PrepTime,CookTime,RecipeId")] RecipeStep recipeStep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeStep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "RecipeName", recipeStep.RecipeId);
            return View(recipeStep);
        }

        // GET: RecipeSteps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeStep recipeStep = db.Recipesteps.Find(id);
            if (recipeStep == null)
            {
                return HttpNotFound();
            }
            return View(recipeStep);
        }

        // POST: RecipeSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeStep recipeStep = db.Recipesteps.Find(id);
            db.Recipesteps.Remove(recipeStep);
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
