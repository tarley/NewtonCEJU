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
    public class RespostaController : Controller
    {
        private CJUContext db = new CJUContext();

        // GET: /Resposta/
        public ActionResult Index()
        {
            var respostas = db.Respostas.Include(r => r.Pergunta);
            return View(respostas.ToList());
        }

        // GET: /Resposta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // GET: /Resposta/Create
        public ActionResult Create()
        {
            ViewBag.PerguntaID = new SelectList(db.Perguntas, "ID", "Descricao");
            return View();
        }

        // POST: /Resposta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PerguntaID,Descricao")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Respostas.Add(resposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PerguntaID = new SelectList(db.Perguntas, "ID", "Descricao", resposta.PerguntaID);
            return View(resposta);
        }

        // GET: /Resposta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerguntaID = new SelectList(db.Perguntas, "ID", "Descricao", resposta.PerguntaID);
            return View(resposta);
        }

        // POST: /Resposta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PerguntaID,Descricao")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PerguntaID = new SelectList(db.Perguntas, "ID", "Descricao", resposta.PerguntaID);
            return View(resposta);
        }

        // GET: /Resposta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // POST: /Resposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resposta resposta = db.Respostas.Find(id);
            db.Respostas.Remove(resposta);
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
