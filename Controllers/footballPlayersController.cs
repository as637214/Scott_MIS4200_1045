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
    public class footballPlayersController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: footballPlayers
        public ActionResult Index()
        {
            return View(db.footballPlayers.ToList());
        }

        // GET: footballPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footballPlayer footballPlayer = db.footballPlayers.Find(id);
            if (footballPlayer == null)
            {
                return HttpNotFound();
            }
            return View(footballPlayer);
        }

        // GET: footballPlayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: footballPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "footballPlayerID,firstName,lastName,position,footballPlayerSince")] footballPlayer footballPlayer)
        {
            if (ModelState.IsValid)
            {
                db.footballPlayers.Add(footballPlayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footballPlayer);
        }

        // GET: footballPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footballPlayer footballPlayer = db.footballPlayers.Find(id);
            if (footballPlayer == null)
            {
                return HttpNotFound();
            }
            return View(footballPlayer);
        }

        // POST: footballPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "footballPlayerID,firstName,lastName,position,footballPlayerSince")] footballPlayer footballPlayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footballPlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footballPlayer);
        }

        // GET: footballPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footballPlayer footballPlayer = db.footballPlayers.Find(id);
            if (footballPlayer == null)
            {
                return HttpNotFound();
            }
            return View(footballPlayer);
        }

        // POST: footballPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            footballPlayer footballPlayer = db.footballPlayers.Find(id);
            db.footballPlayers.Remove(footballPlayer);
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
