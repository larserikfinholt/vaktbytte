using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vaktbytte.Models;

namespace Vaktbytte.Controllers
{
    [Authorize]
    public class ChangeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Change/
        public ActionResult Index()
        {
            return View(db.Change.ToList());
        }

        // GET: /Change/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Change change = db.Change.Find(id);
            if (change == null)
            {
                return HttpNotFound();
            }
            return View(change);
        }

        // GET: /Change/Create
        public ActionResult Create()
        {
            var model = new Change { OwnerUserName = HttpContext.User.Identity.Name, Start=DateTime.Now };
            return View(model);
        }

        // POST: /Change/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Change change)
        {
            if (ModelState.IsValid)
            {
                db.Change.Add(change);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(change);
        }

        // GET: /Change/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Change change = db.Change.Find(id);
            if (change == null)
            {
                return HttpNotFound();
            }
            return View(change);
        }

        // POST: /Change/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Change change)
        {
            if (ModelState.IsValid)
            {
                db.Entry(change).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(change);
        }

        // GET: /Change/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Change change = db.Change.Find(id);
            if (change == null)
            {
                return HttpNotFound();
            }
            return View(change);
        }

        // POST: /Change/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Change change = db.Change.Find(id);
            db.Change.Remove(change);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
