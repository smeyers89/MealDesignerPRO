using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealDesignerPRO.DAL;
using MealDesignerPRO.Models;

namespace MealDesignerPRO.Controllers
{
    public class RefrigeratorsController : Controller
    {
        private MealDesignerContext db = new MealDesignerContext();

        // GET: Refrigerators
        public ActionResult Index()
        {
            var refrigerators = db.Refrigerators.Include(r => r.FoodItem);
            return View(refrigerators.ToList());
        }

        // GET: Refrigerators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerator refrigerator = db.Refrigerators.Find(id);
            if (refrigerator == null)
            {
                return HttpNotFound();
            }
            return View(refrigerator);
        }

        // GET: Refrigerators/Create
        public ActionResult Create()
        {
            ViewBag.FoodItemID = new SelectList(db.FoodItems, "ID", "Name");
            return View();
        }

        // POST: Refrigerators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Quantity,FoodItemID")] Refrigerator refrigerator)
        {
            if (ModelState.IsValid)
            {
                db.Refrigerators.Add(refrigerator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodItemID = new SelectList(db.FoodItems, "ID", "Name", refrigerator.FoodItemID);
            return View(refrigerator);
        }

        // GET: Refrigerators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerator refrigerator = db.Refrigerators.Find(id);
            if (refrigerator == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodItemID = new SelectList(db.FoodItems, "ID", "Name", refrigerator.FoodItemID);
            return View(refrigerator);
        }

        // POST: Refrigerators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Quantity,FoodItemID")] Refrigerator refrigerator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refrigerator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodItemID = new SelectList(db.FoodItems, "ID", "Name", refrigerator.FoodItemID);
            return View(refrigerator);
        }

        // GET: Refrigerators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerator refrigerator = db.Refrigerators.Find(id);
            if (refrigerator == null)
            {
                return HttpNotFound();
            }
            return View(refrigerator);
        }

        // POST: Refrigerators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Refrigerator refrigerator = db.Refrigerators.Find(id);
            db.Refrigerators.Remove(refrigerator);
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
