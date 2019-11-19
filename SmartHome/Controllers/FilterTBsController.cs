using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartHome.Models;
//
using PagedList;
using PagedList.Mvc;

namespace SmartHome.Controllers
{
    public class FilterTBsController : Controller
    {
        private SmartHomeDBEntities db = new SmartHomeDBEntities();

        // GET: FilterTBs
        public ActionResult Index(int page=1)
        {
            return View(db.FilterTBs.ToList().OrderByDescending(a=>a.id).ToPagedList(page,3));
        }

        // GET: FilterTBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilterTB filterTB = db.FilterTBs.Find(id);
            if (filterTB == null)
            {
                return HttpNotFound();
            }
            return View(filterTB);
        }

        // GET: FilterTBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilterTBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NameOfLevel,StartData,EndData")] FilterTB filterTB)
        {
            if (ModelState.IsValid)
            {
                db.FilterTBs.Add(filterTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filterTB);
        }

        // GET: FilterTBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilterTB filterTB = db.FilterTBs.Find(id);
            if (filterTB == null)
            {
                return HttpNotFound();
            }
            return View(filterTB);
        }

        // POST: FilterTBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NameOfLevel,StartData,EndData")] FilterTB filterTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filterTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filterTB);
        }

        // GET: FilterTBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilterTB filterTB = db.FilterTBs.Find(id);
            if (filterTB == null)
            {
                return HttpNotFound();
            }
            return View(filterTB);
        }

        // POST: FilterTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilterTB filterTB = db.FilterTBs.Find(id);
            db.FilterTBs.Remove(filterTB);
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
