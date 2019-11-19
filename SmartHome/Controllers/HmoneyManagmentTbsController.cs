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
    public class HmoneyManagmentTbsController : Controller
    {
        private SmartHomeDBEntities db = new SmartHomeDBEntities();

        // GET: HmoneyManagmentTbs
        public ActionResult Index(int page=1)
        {
            return View(db.HmoneyManagmentTbs.ToList().OrderByDescending(a => a.ID).ToPagedList(page,3));
        }

        // GET: HmoneyManagmentTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HmoneyManagmentTb hmoneyManagmentTb = db.HmoneyManagmentTbs.Find(id);
            if (hmoneyManagmentTb == null)
            {
                return HttpNotFound();
            }
            return View(hmoneyManagmentTb);
        }

        // GET: HmoneyManagmentTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HmoneyManagmentTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataOFTake,Description")] HmoneyManagmentTb hmoneyManagmentTb)
        {
            if (ModelState.IsValid)
            {
                db.HmoneyManagmentTbs.Add(hmoneyManagmentTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hmoneyManagmentTb);
        }

        // GET: HmoneyManagmentTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HmoneyManagmentTb hmoneyManagmentTb = db.HmoneyManagmentTbs.Find(id);
            if (hmoneyManagmentTb == null)
            {
                return HttpNotFound();
            }
            return View(hmoneyManagmentTb);
        }

        // POST: HmoneyManagmentTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DataOFTake,Description")] HmoneyManagmentTb hmoneyManagmentTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hmoneyManagmentTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hmoneyManagmentTb);
        }

        // GET: HmoneyManagmentTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HmoneyManagmentTb hmoneyManagmentTb = db.HmoneyManagmentTbs.Find(id);
            if (hmoneyManagmentTb == null)
            {
                return HttpNotFound();
            }
            return View(hmoneyManagmentTb);
        }

        // POST: HmoneyManagmentTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HmoneyManagmentTb hmoneyManagmentTb = db.HmoneyManagmentTbs.Find(id);
            db.HmoneyManagmentTbs.Remove(hmoneyManagmentTb);
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
