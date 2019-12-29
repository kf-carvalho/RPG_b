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
    public class PulsoRunicoesController : Controller
    {
        private Context db = new Context();

        // GET: PulsoRunicoes
        public ActionResult Index()
        {
            return View(db.PulsoRunicos.ToList());
        }

        // GET: PulsoRunicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PulsoRunico pulsoRunico = db.PulsoRunicos.Find(id);
            if (pulsoRunico == null)
            {
                return HttpNotFound();
            }
            return View(pulsoRunico);
        }

        // GET: PulsoRunicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PulsoRunicoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PulsoRunicoId,Descriçao,Nome")] PulsoRunico pulsoRunico)
        {
            if (ModelState.IsValid)
            {
                db.PulsoRunicos.Add(pulsoRunico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pulsoRunico);
        }

        // GET: PulsoRunicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PulsoRunico pulsoRunico = db.PulsoRunicos.Find(id);
            if (pulsoRunico == null)
            {
                return HttpNotFound();
            }
            return View(pulsoRunico);
        }

        // POST: PulsoRunicoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PulsoRunicoId,Descriçao,Nome")] PulsoRunico pulsoRunico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pulsoRunico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pulsoRunico);
        }

        // GET: PulsoRunicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PulsoRunico pulsoRunico = db.PulsoRunicos.Find(id);
            if (pulsoRunico == null)
            {
                return HttpNotFound();
            }
            return View(pulsoRunico);
        }

        // POST: PulsoRunicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PulsoRunico pulsoRunico = db.PulsoRunicos.Find(id);
            db.PulsoRunicos.Remove(pulsoRunico);
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
