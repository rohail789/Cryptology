using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cryptology;

namespace Cryptology.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExchngesController : Controller
    {
        private CryptologyDbContext db = new CryptologyDbContext();

        // GET: Exchnges
        public ActionResult Index()
        {
            return View(db.Exchnges.ToList());
        }

        // GET: Exchnges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exchnge exchnge = db.Exchnges.Find(id);
            if (exchnge == null)
            {
                return HttpNotFound();
            }
            return View(exchnge);
        }

        // GET: Exchnges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exchnges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eId,ename")] Exchnge exchnge)
        {
            if (ModelState.IsValid)
            {
                db.Exchnges.Add(exchnge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exchnge);
        }

        // GET: Exchnges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exchnge exchnge = db.Exchnges.Find(id);
            if (exchnge == null)
            {
                return HttpNotFound();
            }
            return View(exchnge);
        }

        // POST: Exchnges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eId,ename")] Exchnge exchnge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchnge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exchnge);
        }

        // GET: Exchnges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exchnge exchnge = db.Exchnges.Find(id);
            if (exchnge == null)
            {
                return HttpNotFound();
            }
            return View(exchnge);
        }

        // POST: Exchnges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exchnge exchnge = db.Exchnges.Find(id);
            db.Exchnges.Remove(exchnge);
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
