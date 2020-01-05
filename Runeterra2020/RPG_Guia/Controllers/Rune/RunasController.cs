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

namespace RPG_Guia.Controllers.Rune
{
    public class RunasController : Controller
    {
        private Context db = new Context();

        // GET: Runas
        public ActionResult Index()
        {
            var runas = db.Runas.Include(r => r.Escala);
            return View(runas.ToList());
        }

        // GET: Runas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runa runa = db.Runas.Find(id);
            if (runa == null)
            {
                return HttpNotFound();
            }
            return View(runa);
        }

        // GET: Runas/Create
        public ActionResult Create()
        {
            ViewBag.EscalaRunicaId = new SelectList(db.EscalaRunicas, "EscalaRunicaId", "Nome");
            return View();
        }

        // POST: Runas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RunaId,Descriçao,Nivel,Nome,EscalaRunicaId,Alcance,Cura,Duracao,Dano,Uso")] Runa runa)
        {
            if (ModelState.IsValid)
            {
                db.Runas.Add(runa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EscalaRunicaId = new SelectList(db.EscalaRunicas, "EscalaRunicaId", "Nome", runa.EscalaRunicaId);
            return View(runa);
        }

        // GET: Runas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runa runa = db.Runas.Find(id);
            if (runa == null)
            {
                return HttpNotFound();
            }
            ViewBag.EscalaRunicaId = new SelectList(db.EscalaRunicas, "EscalaRunicaId", "Nome", runa.EscalaRunicaId);
            return View(runa);
        }

        // POST: Runas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RunaId,Descriçao,Nivel,Nome,EscalaRunicaId,Alcance,Cura,Duracao,Dano,Uso")] Runa runa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(runa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EscalaRunicaId = new SelectList(db.EscalaRunicas, "EscalaRunicaId", "Nome", runa.EscalaRunicaId);
            return View(runa);
        }

        // GET: Runas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runa runa = db.Runas.Find(id);
            if (runa == null)
            {
                return HttpNotFound();
            }
            return View(runa);
        }

        // POST: Runas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Runa runa = db.Runas.Find(id);
            db.Runas.Remove(runa);
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
