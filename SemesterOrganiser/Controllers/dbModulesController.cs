using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SemesterOrganiser;

namespace SemesterOrganiser.Controllers
{
    [Authorize]
    public class dbModulesController : Controller
    {
        private SemesterEntities db = new SemesterEntities();

        // GET: dbModules
        public ActionResult Index()
        {
            return View(db.dbModules.ToList());
        }

        // GET: dbModules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbModule dbModule = db.dbModules.Find(id);
            if (dbModule == null)
            {
                return HttpNotFound();
            }
            return View(dbModule);
        }

        // GET: dbModules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dbModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleID,ModuleCode,ModuleName,StartDate")] dbModule dbModule)
        {
            if (ModelState.IsValid)
            {
                db.dbModules.Add(dbModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbModule);
        }

        // GET: dbModules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbModule dbModule = db.dbModules.Find(id);
            if (dbModule == null)
            {
                return HttpNotFound();
            }
            return View(dbModule);
        }

        // POST: dbModules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleID,ModuleCode,ModuleName,StartDate")] dbModule dbModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbModule);
        }

        // GET: dbModules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbModule dbModule = db.dbModules.Find(id);
            if (dbModule == null)
            {
                return HttpNotFound();
            }
            return View(dbModule);
        }

        // POST: dbModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dbModule dbModule = db.dbModules.Find(id);
            db.dbModules.Remove(dbModule);
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
