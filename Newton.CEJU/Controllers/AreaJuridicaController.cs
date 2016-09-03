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
    public class AreaJuridicaController : Controller
    {
        private CJUContext db = new CJUContext();

        // GET: /AreaJuridica/
        public ActionResult Index()
        {
            return View(db.AreasJuridicas.ToList());
        }

        // GET: /AreaJuridica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaJuridica areajuridica = db.AreasJuridicas.Find(id);
            if (areajuridica == null)
            {
                return HttpNotFound();
            }
            return View(areajuridica);
        }

        // GET: /AreaJuridica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AreaJuridica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Area")] AreaJuridica areajuridica)
        {
            if (ModelState.IsValid)
            {
                db.AreasJuridicas.Add(areajuridica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areajuridica);
        }

        // GET: /AreaJuridica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaJuridica areajuridica = db.AreasJuridicas.Find(id);
            if (areajuridica == null)
            {
                return HttpNotFound();
            }
            return View(areajuridica);
        }

        // POST: /AreaJuridica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Area")] AreaJuridica areajuridica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areajuridica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areajuridica);
        }

        // GET: /AreaJuridica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaJuridica areajuridica = db.AreasJuridicas.Find(id);
            if (areajuridica == null)
            {
                return HttpNotFound();
            }
            return View(areajuridica);
        }

        // POST: /AreaJuridica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaJuridica areajuridica = db.AreasJuridicas.Find(id);
            db.AreasJuridicas.Remove(areajuridica);
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
