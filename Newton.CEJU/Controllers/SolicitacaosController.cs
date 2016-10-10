﻿using System;
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
using Newton.CJU.ViewModel;
using System.Data.Entity.Validation;

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
            SolicitacaoViewModel v_SolicitacaoViewModel = new SolicitacaoViewModel();
            v_SolicitacaoViewModel.FatosCotidianos = db.FatosCotidiano.OrderBy(p => p.Nome).ToList();
            return View(v_SolicitacaoViewModel);
        }

        // POST: Solicitacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public ActionResult Create(SolicitacaoViewModel solicitacaoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AtividadeSemestral v_AtividadeSemestral = db.AtividadesSemestrais.Where(p => p.AreaConhecimento.FatoCotidiano.Any(o => o.Id == solicitacaoViewModel.IdFatoCotidiano)).FirstOrDefault();
                    FatoCotidiano v_FatoCotidiano = db.FatosCotidiano.Where(p => p.Id == solicitacaoViewModel.IdFatoCotidiano).FirstOrDefault();
                    Situacao v_Situacao = db.Situacoes.FirstOrDefault();

                    Solicitacao v_Solicitacao = new Solicitacao()
                    {
                        AtividadeSemestralId =
                            v_AtividadeSemestral.Id,
                        FatoJuridico = v_FatoCotidiano.Nome,
                        DataCadastro = DateTime.Now,
                        SituacaoId = v_Situacao.Id,
                        UsuarioId = new Guid(User.Identity.GetUserId()),
                        Descricao = solicitacaoViewModel.Descricao,
                        Duvida = solicitacaoViewModel.Duvida,
                        IdentificacaoPartes = solicitacaoViewModel.IdentificacaoPartes
                    };

                    db.Solicitacaos.Add(v_Solicitacao);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return View(solicitacaoViewModel);
          
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
