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
    public class FichasController : Controller
    {
        private Context db = new Context();

        // GET: Fichas
        public ActionResult Index()
        {
            var fichas = db.Fichas.Include(f => f.Classe).Include(f => f.Raça).Include(f => f.Territorio).Include(f => f.Usuario);
            return View(fichas.ToList());
        }

        // GET: Fichas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ficha ficha = db.Fichas.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            return View(ficha);
        }

        // GET: Fichas/Create
        public ActionResult Create()
        {
            ViewBag.ClasseId = new SelectList(db.Classes, "ClasseId", "Descriçao");
            ViewBag.RaçaId = new SelectList(db.Raças, "RaçaId", "Descriçao");
            ViewBag.TerritorioId = new SelectList(db.Territorios, "TerritorioId", "Descriçao");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario");
            return View();
        }

        // POST: Fichas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FichaId,Nome,Antepassado,Tendencia,Personalidade,Ideal,Vinculo,Fraqueza,Caracteristica,Força,Inteligencia,Sabedoria,Destreza,Constituição,Carisma,ClasseArmadura,UsuarioId,TerritorioId,RaçaId,ClasseId")] Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                db.Fichas.Add(ficha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseId = new SelectList(db.Classes, "ClasseId", "Descriçao", ficha.ClasseId);
            ViewBag.RaçaId = new SelectList(db.Raças, "RaçaId", "Descriçao", ficha.RaçaId);
            ViewBag.TerritorioId = new SelectList(db.Territorios, "TerritorioId", "Descriçao", ficha.TerritorioId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario", ficha.UsuarioId);
            return View(ficha);
        }

        // GET: Fichas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ficha ficha = db.Fichas.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "ClasseId", "Descriçao", ficha.ClasseId);
            ViewBag.RaçaId = new SelectList(db.Raças, "RaçaId", "Descriçao", ficha.RaçaId);
            ViewBag.TerritorioId = new SelectList(db.Territorios, "TerritorioId", "Descriçao", ficha.TerritorioId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario", ficha.UsuarioId);
            return View(ficha);
        }

        // POST: Fichas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FichaId,Nome,Antepassado,Tendencia,Personalidade,Ideal,Vinculo,Fraqueza,Caracteristica,Força,Inteligencia,Sabedoria,Destreza,Constituição,Carisma,ClasseArmadura,UsuarioId,TerritorioId,RaçaId,ClasseId")] Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ficha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "ClasseId", "Descriçao", ficha.ClasseId);
            ViewBag.RaçaId = new SelectList(db.Raças, "RaçaId", "Descriçao", ficha.RaçaId);
            ViewBag.TerritorioId = new SelectList(db.Territorios, "TerritorioId", "Descriçao", ficha.TerritorioId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario", ficha.UsuarioId);
            return View(ficha);
        }

        // GET: Fichas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ficha ficha = db.Fichas.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            return View(ficha);
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ficha ficha = db.Fichas.Find(id);
            db.Fichas.Remove(ficha);
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
