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
    public class ArmasController : Controller
    {
        private Context db = new Context();

        // GET: Armas
        public ActionResult Index()
        {
            return View(db.Armas.ToList());
        }

        // GET: Armas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arma arma = db.Armas.Find(id);
            if (arma == null)
            {
                return HttpNotFound();
            }
            return View(arma);
        }

        // GET: Armas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArmaId,Nome,Categoria,Preço,Peso,Dano,Propriedades")] Arma arma)
        {
            if (ModelState.IsValid)
            {
                db.Armas.Add(arma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arma);
        }

        // GET: Armas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arma arma = db.Armas.Find(id);
            if (arma == null)
            {
                return HttpNotFound();
            }
            return View(arma);
        }

        // POST: Armas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArmaId,Nome,Categoria,Preço,Peso,Dano,Propriedades")] Arma arma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arma);
        }

        // GET: Armas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arma arma = db.Armas.Find(id);
            if (arma == null)
            {
                return HttpNotFound();
            }
            return View(arma);
        }

        // POST: Armas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arma arma = db.Armas.Find(id);
            db.Armas.Remove(arma);
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
