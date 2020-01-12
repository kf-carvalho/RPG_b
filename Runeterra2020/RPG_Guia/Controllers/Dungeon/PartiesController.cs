using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RPG_Guia.Data;
using RPG_Guia.Models;

namespace RPG_Guia.Controllers.Dungeon
{
    public class PartiesController : Controller
    {
        private Context db = new Context();

        // GET: Parties
        public ActionResult Index()
        {
            return View(db.Parties.ToList());
        }

        // GET: Parties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // GET: Parties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parties/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartyId,Nome")] Party party)
        {
            if (ModelState.IsValid)
            {
                db.Parties.Add(party);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(party);
        }

        // GET: Parties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // POST: Parties/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartyId,Nome")] Party party)
        {
            if (ModelState.IsValid)
            {
                db.Entry(party).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(party);
        }

        // GET: Parties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Party party = db.Parties.Find(id);
            db.Parties.Remove(party);
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
