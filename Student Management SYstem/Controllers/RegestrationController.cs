using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_Management_SYstem.Models;

namespace Student_Management_SYstem.Controllers
{
    public class RegestrationController : Controller
    {
        private stdEntities1 db = new stdEntities1();

        // GET: Regestration
        public ActionResult Index()
        {
            var regestrations = db.regestrations.Include(r => r.batch).Include(r => r.Course);
            return View(regestrations.ToList());
        }

        // GET: Regestration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regestration regestration = db.regestrations.Find(id);
            if (regestration == null)
            {
                return HttpNotFound();
            }
            return View(regestration);
        }

        // GET: Regestration/Create
        public ActionResult Create()
        {
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1");
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1");
            return View();
        }

        // POST: Regestration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] regestration regestration)
        {
            if (ModelState.IsValid)
            {
                db.regestrations.Add(regestration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", regestration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", regestration.course_id);
            return View(regestration);
        }

        // GET: Regestration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regestration regestration = db.regestrations.Find(id);
            if (regestration == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", regestration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", regestration.course_id);
            return View(regestration);
        }

        // POST: Regestration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] regestration regestration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regestration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", regestration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", regestration.course_id);
            return View(regestration);
        }

        // GET: Regestration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regestration regestration = db.regestrations.Find(id);
            if (regestration == null)
            {
                return HttpNotFound();
            }
            return View(regestration);
        }

        // POST: Regestration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            regestration regestration = db.regestrations.Find(id);
            db.regestrations.Remove(regestration);
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
