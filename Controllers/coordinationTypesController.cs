using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scott_MIS4200_1045.DAL;
using Scott_MIS4200_1045.Models;

namespace Scott_MIS4200_1045.Controllers
{
    public class coordinationTypesController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: coordinationTypes
        public ActionResult Index()
        {
            var coordinationTypes = db.coordinationTypes.Include(c => c.footballPlayer);
            return View(coordinationTypes.ToList());
        }

        // GET: coordinationTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coordinationType coordinationType = db.coordinationTypes.Find(id);
            if (coordinationType == null)
            {
                return HttpNotFound();
            }
            return View(coordinationType);
        }

        // GET: coordinationTypes/Create
        public ActionResult Create()
        {
            ViewBag.footballPlayerID = new SelectList(db.footballPlayers, "footballPlayerID", "firstName");
            return View();
        }

        // POST: coordinationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "coordinationTypeID,description,CoordinationName,coachID,footballPlayerID")] coordinationType coordinationType)
        {
            if (ModelState.IsValid)
            {
                db.coordinationTypes.Add(coordinationType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.footballPlayerID = new SelectList(db.footballPlayers, "footballPlayerID", "firstName", coordinationType.footballPlayerID);
            return View(coordinationType);
        }

        // GET: coordinationTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coordinationType coordinationType = db.coordinationTypes.Find(id);
            if (coordinationType == null)
            {
                return HttpNotFound();
            }
            ViewBag.footballPlayerID = new SelectList(db.footballPlayers, "footballPlayerID", "firstName", coordinationType.footballPlayerID);
            return View(coordinationType);
        }

        // POST: coordinationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coordinationTypeID,description,CoordinationName,coachID,footballPlayerID")] coordinationType coordinationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coordinationType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.footballPlayerID = new SelectList(db.footballPlayers, "footballPlayerID", "firstName", coordinationType.footballPlayerID);
            return View(coordinationType);
        }

        // GET: coordinationTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coordinationType coordinationType = db.coordinationTypes.Find(id);
            if (coordinationType == null)
            {
                return HttpNotFound();
            }
            return View(coordinationType);
        }

        // POST: coordinationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            coordinationType coordinationType = db.coordinationTypes.Find(id);
            db.coordinationTypes.Remove(coordinationType);
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
