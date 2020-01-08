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

namespace RPG_Guia.Controllers
{
    public class RaçaController : Controller
    {
        private Context db = new Context();

        // GET: Raça
        public ActionResult Index()
        {
            return View(db.Raças.ToList());
        }

        // GET: Raça/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raça raça = db.Raças.Find(id);
            if (raça == null)
            {
                return HttpNotFound();
            }
            return View(raça);
        }

        // GET: Raça/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raça/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaçaId,Descriçao,Nome")] Raça raça)
        {
            if (ModelState.IsValid)
            {
                db.Raças.Add(raça);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raça);
        }

        // GET: Raça/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raça raça = db.Raças.Find(id);
            if (raça == null)
            {
                return HttpNotFound();
            }
            return View(raça);
        }

        // POST: Raça/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaçaId,Descriçao,Nome")] Raça raça)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raça).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raça);
        }

        // GET: Raça/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raça raça = db.Raças.Find(id);
            if (raça == null)
            {
                return HttpNotFound();
            }
            return View(raça);
        }

        // POST: Raça/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raça raça = db.Raças.Find(id);
            db.Raças.Remove(raça);
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
