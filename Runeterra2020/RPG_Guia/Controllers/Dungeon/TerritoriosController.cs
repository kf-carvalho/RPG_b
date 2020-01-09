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
    public class TerritoriosController : Controller
    {
        private Context db = new Context();

        // GET: Territorios
        public ActionResult Index()
        {
            return View(db.Territorios.ToList());
        }

        // GET: Territorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territorio territorio = db.Territorios.Find(id);
            if (territorio == null)
            {
                return HttpNotFound();
            }
            return View(territorio);
        }

        // GET: Territorios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Territorios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerritorioId,Descriçao,Nome")] Territorio territorio)
        {
            if (ModelState.IsValid)
            {
                db.Territorios.Add(territorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(territorio);
        }

        // GET: Territorios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territorio territorio = db.Territorios.Find(id);
            if (territorio == null)
            {
                return HttpNotFound();
            }
            return View(territorio);
        }

        // POST: Territorios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerritorioId,Descriçao,Nome")] Territorio territorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(territorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(territorio);
        }

        // GET: Territorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territorio territorio = db.Territorios.Find(id);
            if (territorio == null)
            {
                return HttpNotFound();
            }
            return View(territorio);
        }

        // POST: Territorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Territorio territorio = db.Territorios.Find(id);
            db.Territorios.Remove(territorio);
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
