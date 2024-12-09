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
    public class dbModuleDetailsController : Controller
    {
        private SemesterEntities db = new SemesterEntities();

        // GET: dbModuleDetails
        public ActionResult Index()
        {
            return View(db.dbModuleDetails.ToList());
        }

        // GET: dbModuleDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbModuleDetail dbModuleDetail = db.dbModuleDetails.Find(id);
            if (dbModuleDetail == null)
            {
                return HttpNotFound();
            }
            return View(dbModuleDetail);
        }

        // GET: dbModuleDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dbModuleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleDetailID,NumberOfCredits,NumberOfWeeks,ClassHoursPerWeek,ModuleHours")] dbModuleDetail dbModuleDetail)
        {
            if (ModelState.IsValid)
            {
                db.dbModuleDetails.Add(dbModuleDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbModuleDetail);
        }

        // GET: dbModuleDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbModuleDetail dbModuleDetail = db.dbModuleDetails.Find(id);
            if (dbModuleDetail == null)
            {
                return HttpNotFound();
            }
            return View(dbModuleDetail);
        }

        // POST: dbModuleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleDetailID,NumberOfCredits,NumberOfWeeks,ClassHoursPerWeek,ModuleHours")] dbModuleDetail dbModuleDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbModuleDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbModuleDetail);
        }

        // GET: dbModuleDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbModuleDetail dbModuleDetail = db.dbModuleDetails.Find(id);
            if (dbModuleDetail == null)
            {
                return HttpNotFound();
            }
            return View(dbModuleDetail);
        }

        // POST: dbModuleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dbModuleDetail dbModuleDetail = db.dbModuleDetails.Find(id);
            db.dbModuleDetails.Remove(dbModuleDetail);
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
