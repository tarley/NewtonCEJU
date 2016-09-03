using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newton.CJU.Models;
using Newton.CJU.DAL;

namespace Newton.CJU.Controllers
{
    public class PerguntaController : Controller
    {
        private CJUContext db = new CJUContext();

        // GET: /Pergunta/
        public ActionResult Index()
        {
            var perguntas = db.Perguntas.Include(p => p.AreaJuridica);
            return View(perguntas.ToList());
        }

        // GET: /Pergunta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Perguntas.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // GET: /Pergunta/Create
        public ActionResult Create()
        {
            ViewBag.AreaJuridicaID = new SelectList(db.AreasJuridicas, "ID", "Area");
            return View();
        }

        // POST: /Pergunta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,AreaJuridicaID,Descricao,Repondido")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                db.Perguntas.Add(pergunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaJuridicaID = new SelectList(db.AreasJuridicas, "ID", "Area", pergunta.AreaJuridicaID);
            return View(pergunta);
        }

        // GET: /Pergunta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Perguntas.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaJuridicaID = new SelectList(db.AreasJuridicas, "ID", "Area", pergunta.AreaJuridicaID);
            return View(pergunta);
        }

        // POST: /Pergunta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,AreaJuridicaID,Descricao,Repondido")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pergunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaJuridicaID = new SelectList(db.AreasJuridicas, "ID", "Area", pergunta.AreaJuridicaID);
            return View(pergunta);
        }

        // GET: /Pergunta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Perguntas.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // POST: /Pergunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pergunta pergunta = db.Perguntas.Find(id);
            db.Perguntas.Remove(pergunta);
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
