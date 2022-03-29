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
    public class RecipeIncredientsController : Controller
    {
        private RecipeContext db = new RecipeContext();

        // GET: RecipeIncredients
        public ActionResult Index()
        {
            var recipeincredients = db.Recipeincredients.Include(r => r.Incredient).Include(r => r.Recipe);
            return View(recipeincredients.ToList());
        }

        // GET: RecipeIncredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIncredient recipeIncredient = db.Recipeincredients.Find(id);
            if (recipeIncredient == null)
            {
                return HttpNotFound();
            }
            return View(recipeIncredient);
        }

        // GET: RecipeIncredients/Create
        public ActionResult Create()
        {
            ViewBag.IncredientId = new SelectList(db.Incredients, "IncredientId", "IncredientName");
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "RecipeName");
            return View();
        }

        // POST: RecipeIncredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecipeIncredientName,AmountRequired,RecipeId,IncredientId")] RecipeIncredient recipeIncredient)
        {
            if (ModelState.IsValid)
            {
                db.Recipeincredients.Add(recipeIncredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IncredientId = new SelectList(db.Incredients, "IncredientId", "IncredientName", recipeIncredient.IncredientId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "RecipeName", recipeIncredient.RecipeId);
            return View(recipeIncredient);
        }

        // GET: RecipeIncredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIncredient recipeIncredient = db.Recipeincredients.Find(id);
            if (recipeIncredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IncredientId = new SelectList(db.Incredients, "IncredientId", "IncredientName", recipeIncredient.IncredientId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "RecipeName", recipeIncredient.RecipeId);
            return View(recipeIncredient);
        }

        // POST: RecipeIncredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecipeIncredientName,AmountRequired,RecipeId,IncredientId")] RecipeIncredient recipeIncredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeIncredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IncredientId = new SelectList(db.Incredients, "IncredientId", "IncredientName", recipeIncredient.IncredientId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "RecipeName", recipeIncredient.RecipeId);
            return View(recipeIncredient);
        }

        // GET: RecipeIncredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIncredient recipeIncredient = db.Recipeincredients.Find(id);
            if (recipeIncredient == null)
            {
                return HttpNotFound();
            }
            return View(recipeIncredient);
        }

        // POST: RecipeIncredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeIncredient recipeIncredient = db.Recipeincredients.Find(id);
            db.Recipeincredients.Remove(recipeIncredient);
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
