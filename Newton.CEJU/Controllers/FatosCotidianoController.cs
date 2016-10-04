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
    public class FatosCotidianoController : Controller
    {
        private CJUContext db = new CJUContext();

        // GET: FatosCotidiano
        public ActionResult Index()
        {
            var fatosCotidiano = db.FatosCotidiano.Include(f => f.AreaConhecimento);
            return View(fatosCotidiano.ToList());
        }

        // GET: FatosCotidiano/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FatoCotidiano fatoCotidiano = db.FatosCotidiano.Find(id);
            if (fatoCotidiano == null)
            {
                return HttpNotFound();
            }
            return View(fatoCotidiano);
        }

        // GET: FatosCotidiano/Create
        public ActionResult Create()
        {
            ViewBag.AreaConhecimentoId = new SelectList(db.AreasConhecimento, "Id", "Nome");
            return View();
        }

        // POST: FatosCotidiano/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AreaConhecimentoId,Nome")] FatoCotidiano fatoCotidiano)
        {
            if (ModelState.IsValid)
            {
                db.FatosCotidiano.Add(fatoCotidiano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaConhecimentoId = new SelectList(db.AreasConhecimento, "Id", "Nome", fatoCotidiano.AreaConhecimentoId);
            return View(fatoCotidiano);
        }

        // GET: FatosCotidiano/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FatoCotidiano fatoCotidiano = db.FatosCotidiano.Find(id);
            if (fatoCotidiano == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaConhecimentoId = new SelectList(db.AreasConhecimento, "Id", "Nome", fatoCotidiano.AreaConhecimentoId);
            return View(fatoCotidiano);
        }

        // POST: FatosCotidiano/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AreaConhecimentoId,Nome")] FatoCotidiano fatoCotidiano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fatoCotidiano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaConhecimentoId = new SelectList(db.AreasConhecimento, "Id", "Nome", fatoCotidiano.AreaConhecimentoId);
            return View(fatoCotidiano);
        }

        // GET: FatosCotidiano/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FatoCotidiano fatoCotidiano = db.FatosCotidiano.Find(id);
            if (fatoCotidiano == null)
            {
                return HttpNotFound();
            }
            return View(fatoCotidiano);
        }

        // POST: FatosCotidiano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FatoCotidiano fatoCotidiano = db.FatosCotidiano.Find(id);
            db.FatosCotidiano.Remove(fatoCotidiano);
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
