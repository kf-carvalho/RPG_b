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
    public class EscalaRunicasController : Controller
    {
        private Context db = new Context();

        // GET: EscalaRunicas
        public ActionResult Index()
        {
            return View(db.EscalaRunicas.ToList());
        }

        // GET: EscalaRunicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EscalaRunica escalaRunica = db.EscalaRunicas.Find(id);
            if (escalaRunica == null)
            {
                return HttpNotFound();
            }
            return View(escalaRunica);
        }

        // GET: EscalaRunicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EscalaRunicas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EscalaRunicaId,Nome")] EscalaRunica escalaRunica)
        {
            if (ModelState.IsValid)
            {
                db.EscalaRunicas.Add(escalaRunica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escalaRunica);
        }

        // GET: EscalaRunicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EscalaRunica escalaRunica = db.EscalaRunicas.Find(id);
            if (escalaRunica == null)
            {
                return HttpNotFound();
            }
            return View(escalaRunica);
        }

        // POST: EscalaRunicas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EscalaRunicaId,Nome")] EscalaRunica escalaRunica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escalaRunica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escalaRunica);
        }

        // GET: EscalaRunicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EscalaRunica escalaRunica = db.EscalaRunicas.Find(id);
            if (escalaRunica == null)
            {
                return HttpNotFound();
            }
            return View(escalaRunica);
        }

        // POST: EscalaRunicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EscalaRunica escalaRunica = db.EscalaRunicas.Find(id);
            db.EscalaRunicas.Remove(escalaRunica);
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
