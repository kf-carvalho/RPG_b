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
    public class PericiasController : Controller
    {
        private Context db = new Context();

        // GET: Pericias
        public ActionResult Index()
        {
            return View(db.Pericias.ToList());
        }

        // GET: Pericias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pericia pericia = db.Pericias.Find(id);
            if (pericia == null)
            {
                return HttpNotFound();
            }
            return View(pericia);
        }

        // GET: Pericias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pericias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PericiaId,Modificador,Mastery,Proeficiencia")] Pericia pericia)
        {
            if (ModelState.IsValid)
            {
                db.Pericias.Add(pericia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pericia);
        }

        // GET: Pericias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pericia pericia = db.Pericias.Find(id);
            if (pericia == null)
            {
                return HttpNotFound();
            }
            return View(pericia);
        }

        // POST: Pericias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PericiaId,Modificador,Mastery,Proeficiencia")] Pericia pericia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pericia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pericia);
        }

        // GET: Pericias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pericia pericia = db.Pericias.Find(id);
            if (pericia == null)
            {
                return HttpNotFound();
            }
            return View(pericia);
        }

        // POST: Pericias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pericia pericia = db.Pericias.Find(id);
            db.Pericias.Remove(pericia);
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
