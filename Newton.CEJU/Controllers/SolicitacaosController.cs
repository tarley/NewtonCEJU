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
using Microsoft.AspNet.Identity;

namespace Newton.CJU.Controllers
{
    public class SolicitacaosController : Controller
    {
        private CJUContext db = new CJUContext();

        // GET: Solicitacaos
        [Authorize(Roles = "Cliente, Professor, Monitor")]
        public ActionResult Index()
        {
            var solicitacaos = db.Solicitacaos.Include(s => s.AtividadeSemestral).Include(s => s.Historico).Include(s => s.Situacao);
            return View(solicitacaos.ToList());
        }

        // GET: Solicitacaos/Details/5
        [Authorize(Roles = "Cliente, Professor, Monitor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = db.Solicitacaos.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        // GET: Solicitacaos/Create
        [Authorize(Roles = "Cliente")]
        public ActionResult Create()
        {
            ViewBag.AtividadeSemestralId = new SelectList(db.AtividadesSemestrais, "Id", "Ano");
            ViewBag.FatoCotidiano = new SelectList(db.FatosCotidiano, "Id", "Nome");
            //ViewBag.HistoricoId = new SelectList(db.Historicos, "Id", "Id");
            //ViewBag.SituacaoId = new SelectList(db.Situacoes, "Id", "Nome");
            return View();
        }

        // POST: Solicitacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public ActionResult Create([Bind(Include = "Id,SituacaoId,HistoricoId,UsuarioId,AtividadeSemestralId,DataCadastro,Duvida,Parecer,FatoJuridico,Fundamentacao,IdentificacaoPartes,Descricao,Correcao")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                solicitacao.DataCadastro = DateTime.Now;
                solicitacao.SituacaoId = 1;
                solicitacao.UsuarioId = new Guid(User.Identity.GetUserId());

                db.Solicitacaos.Add(solicitacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtividadeSemestralId = new SelectList(db.AtividadesSemestrais, "Id", "Id", solicitacao.AtividadeSemestralId);
            ViewBag.HistoricoId = new SelectList(db.Historicos, "Id", "Id", solicitacao.HistoricoId);
            ViewBag.SituacaoId = new SelectList(db.Situacoes, "Id", "Nome", solicitacao.SituacaoId);
            return View(solicitacao);
        }

        // GET: Solicitacaos/Edit/5
        [Authorize(Roles = "Professor, Monitor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = db.Solicitacaos.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtividadeSemestralId = new SelectList(db.AtividadesSemestrais, "Id", "Id", solicitacao.AtividadeSemestralId);
            ViewBag.HistoricoId = new SelectList(db.Historicos, "Id", "Id", solicitacao.HistoricoId);
            ViewBag.SituacaoId = new SelectList(db.Situacoes, "Id", "Nome", solicitacao.SituacaoId);
            return View(solicitacao);
        }

        // POST: Solicitacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor, Monitor")]
        public ActionResult Edit([Bind(Include = "Id,SituacaoId,HistoricoId,UsuarioId,AtividadeSemestralId,DataCadastro,Duvida,Parecer,FatoJuridico,Fundamentacao,IdentificacaoPartes,Descricao,Correcao")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtividadeSemestralId = new SelectList(db.AtividadesSemestrais, "Id", "Id", solicitacao.AtividadeSemestralId);
            ViewBag.HistoricoId = new SelectList(db.Historicos, "Id", "Id", solicitacao.HistoricoId);
            ViewBag.SituacaoId = new SelectList(db.Situacoes, "Id", "Nome", solicitacao.SituacaoId);
            return View(solicitacao);
        }

        // GET: Solicitacaos/Delete/5
        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitacao solicitacao = db.Solicitacaos.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        // POST: Solicitacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor")]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitacao solicitacao = db.Solicitacaos.Find(id);
            db.Solicitacaos.Remove(solicitacao);
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
