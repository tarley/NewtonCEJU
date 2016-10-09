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
    [Authorize(Roles = "Professor, Monitor")]
    public class AreasConhecimentoController : Controller
    {
        private CJUContext db = new CJUContext();

        // GET: AreasConhecimento
        [Authorize(Roles = "Professor")]
        public ActionResult Index()
        {
            return View(db.AreasConhecimento.ToList());
        }

        // GET: AreasConhecimento/Details/5
        [Authorize(Roles = "Professor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaConhecimento areaConhecimento = db.AreasConhecimento.Find(id);
            if (areaConhecimento == null)
            {
                return HttpNotFound();
            }
            return View(areaConhecimento);
        }

        // GET: AreasConhecimento/Create
        [Authorize(Roles = "Professor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreasConhecimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Professor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ativo")] AreaConhecimento areaConhecimento)
        {
            if (ModelState.IsValid)
            {
                db.AreasConhecimento.Add(areaConhecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areaConhecimento);
        }

        // GET: AreasConhecimento/Edit/5
        [Authorize(Roles = "Professor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaConhecimento areaConhecimento = db.AreasConhecimento.Find(id);
            if (areaConhecimento == null)
            {
                return HttpNotFound();
            }
            return View(areaConhecimento);
        }

        // POST: AreasConhecimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Professor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ativo")] AreaConhecimento areaConhecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaConhecimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaConhecimento);
        }

        // GET: AreasConhecimento/Delete/5
        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaConhecimento areaConhecimento = db.AreasConhecimento.Find(id);
            if (areaConhecimento == null)
            {
                return HttpNotFound();
            }
            return View(areaConhecimento);
        }

        // POST: AreasConhecimento/Delete/5
        [Authorize(Roles = "Professor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaConhecimento areaConhecimento = db.AreasConhecimento.Find(id);
            db.AreasConhecimento.Remove(areaConhecimento);
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
