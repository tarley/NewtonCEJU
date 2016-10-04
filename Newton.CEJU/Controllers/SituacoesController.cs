using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newton.CJU.DAL;
using Newton.CJU.Models;

namespace Newton.CJU.Controllers
{
    public class SituacoesController : Controller
    {
        private CJUContext db = new CJUContext();

        // GET: Situacoes
        public ActionResult Index()
        {
            return View(db.Situacoes.ToList());
        }

        // GET: Situacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.Situacoes.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // GET: Situacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Situacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                db.Situacoes.Add(situacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(situacao);
        }

        // GET: Situacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.Situacoes.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: Situacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(situacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(situacao);
        }

        // GET: Situacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.Situacoes.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: Situacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Situacao situacao = db.Situacoes.Find(id);
            db.Situacoes.Remove(situacao);
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
