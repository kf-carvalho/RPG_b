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
    public class ArmadurasController : Controller
    {
        private Context db = new Context();

        // GET: Armaduras
        public ActionResult Index()
        {
            return View(db.Armaduras.ToList());
        }

        // GET: Armaduras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadura armadura = db.Armaduras.Find(id);
            if (armadura == null)
            {
                return HttpNotFound();
            }
            return View(armadura);
        }

        // GET: Armaduras/Create
        public ActionResult Create()
        {
            var furtiv = new[]{
                new SelectListItem { Value = "Desvantagem", Text = "Desvantagem" },
                new SelectListItem { Value = "Vantagem", Text = "Vantagem" },
                new SelectListItem { Value = "-", Text = "-" },
            };
            ViewBag.Furtividade = new SelectList(furtiv, "Value", "Text");

            var categor = new[]{
                new SelectListItem { Value = "Armadura Leve", Text = "Leve" },
                new SelectListItem { Value = "Armadura Média", Text = "Média" },
                new SelectListItem { Value = "Armadura Pesada ", Text = "Pesada" },
                new SelectListItem { Value = "Escudo", Text = "Escudo" },
            };
            ViewBag.Categoria = new SelectList(categor, "Value", "Text");
            return View();
        }

        // POST: Armaduras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArmaduraId,Nome,Categoria,ClasseArmadura,Força,Furtividade,Peso,Preço")] Armadura armadura)
        {
            var furtiv = new[]{
                new SelectListItem { Value = "Desvantagem", Text = "Desvantagem" },
                new SelectListItem { Value = "Vantagem", Text = "Vantagem" },
                new SelectListItem { Value = "-", Text = "-" },
            };
            ViewBag.Furtividade = new SelectList(furtiv, "Value", "Text");

            var categor = new[]{
                new SelectListItem { Value = "Armadura Leve", Text = "Leve" },
                new SelectListItem { Value = "Armadura Média", Text = "Média" },
                new SelectListItem { Value = "Armadura Pesada ", Text = "Pesada" },
                new SelectListItem { Value = "Escudo", Text = "Escudo" },
            };
            ViewBag.Categoria = new SelectList(categor, "Value", "Text");

            if (ModelState.IsValid)
            {
                db.Armaduras.Add(armadura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(armadura);
        }

        // GET: Armaduras/Edit/5
        public ActionResult Edit(int? id)
        {
            var furtiv = new[]{
                new SelectListItem { Value = "Desvantagem", Text = "Desvantagem" },
                new SelectListItem { Value = "Vantagem", Text = "Vantagem" },
                new SelectListItem { Value = "-", Text = "-" },
            };
            ViewBag.Furtividade = new SelectList(furtiv, "Value", "Text");

            var categor = new[]{
                new SelectListItem { Value = "Armadura Leve", Text = "Leve" },
                new SelectListItem { Value = "Armadura Média", Text = "Média" },
                new SelectListItem { Value = "Armadura Pesada ", Text = "Pesada" },
                new SelectListItem { Value = "Escudo", Text = "Escudo" },
            };
            ViewBag.Categoria = new SelectList(categor, "Value", "Text");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadura armadura = db.Armaduras.Find(id);
            if (armadura == null)
            {
                return HttpNotFound();
            }
            return View(armadura);
        }

        // POST: Armaduras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArmaduraId,Nome,Categoria,ClasseArmadura,Força,Furtividade,Peso,Preço")] Armadura armadura)
        {
            var furtiv = new[]{
                new SelectListItem { Value = "Desvantagem", Text = "Desvantagem" },
                new SelectListItem { Value = "Vantagem", Text = "Vantagem" },
                new SelectListItem { Value = "-", Text = "-" },
            };
            ViewBag.Furtividade = new SelectList(furtiv, "Value", "Text");
            var categor = new[]{
                new SelectListItem { Value = "Armadura Leve", Text = "Leve" },
                new SelectListItem { Value = "Armadura Média", Text = "Média" },
                new SelectListItem { Value = "Armadura Pesada ", Text = "Pesada" },
                new SelectListItem { Value = "Escudo", Text = "Escudo" },
            };
            ViewBag.Categoria = new SelectList(categor, "Value", "Text");

            if (ModelState.IsValid)
            {
                db.Entry(armadura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(armadura);
        }

        // POST: Armaduras/Delete/5]
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Armadura armadura = db.Armaduras.Find(id);

            if (armadura == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                db.Armaduras.Remove(armadura);
                db.SaveChanges();
            }
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
