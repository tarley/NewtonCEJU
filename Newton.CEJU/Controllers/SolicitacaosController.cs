using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newton.CJU.DAL;
using Newton.CJU.Models;
using Newton.CJU.Models.Enum;
using Newton.CJU.ViewModel;
using PagedList;

namespace Newton.CJU.Controllers
{
    public class SolicitacaosController : Controller
    {
        private readonly CJUContext db = new CJUContext();

        // GET: Solicitacaos
        [Authorize(Roles = "Cliente, Professor, Monitor")]
        public ActionResult Index(int? pagina, string datainicial = null, string datafinal = null)
        {
            var contexto = new CadastroEntities();
            var solicitacao = db.Solicitacaos.Include(s => s.AtividadeSemestral).Include(s => s.Historico);
            var TamanhoPagina = 10;
            var NumeroPagina = pagina ?? 1;

            if (!string.IsNullOrEmpty(datainicial))
            {
                DateTime dtinicio;
                if (DateTime.TryParse(datainicial, out dtinicio))
                    solicitacao.Where(s => s.DataCadastro >= dtinicio);
            }

            if (!string.IsNullOrEmpty(datafinal))
            {
                DateTime dtfim;
                if (DateTime.TryParse(datafinal, out dtfim))
                    solicitacao.Where(s => s.DataCadastro <= dtfim);
            }

            var idusuariologado = User.Identity.GetUserId();
            if (User.IsInRole("Cliente"))
                solicitacao.Where(s => s.UsuarioCliente.Id.Equals(idusuariologado));

            if (User.IsInRole("Monitor"))
                solicitacao.Where(s => s.UsuarioAluno.Id.Equals(idusuariologado));

            return View(solicitacao.OrderBy(p => p.Id).ToPagedList(NumeroPagina, TamanhoPagina));
        }

        [HttpPost]
        public ActionResult Pesquisa()
        {
            return RedirectToAction("Index");
        }


        // GET: Solicitacaos/Details/5
        [Authorize(Roles = "Cliente, Professor, Monitor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var solicitacao = db.Solicitacaos.Find(id);
            if (solicitacao == null)
                return HttpNotFound();
            return View(solicitacao);
        }

        // GET: Solicitacaos/Create
        [Authorize(Roles = "Cliente")]
        public ActionResult Create()
        {
            var v_SolicitacaoViewModel = new SolicitacaoViewModel();
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
                    var v_AtividadeSemestral =
                        db.AtividadesSemestrais.Where(
                            p =>
                                p.AreaConhecimento.FatoCotidiano.Any(
                                    o => o.Id == solicitacaoViewModel.IdFatoCotidiano) && p.Ativo).FirstOrDefault();
                    var v_FatoCotidiano =
                        db.FatosCotidiano.Where(p => p.Id == solicitacaoViewModel.IdFatoCotidiano).FirstOrDefault();

                    if (v_AtividadeSemestral == null)
                    {
                        solicitacaoViewModel.FatosCotidianos = db.FatosCotidiano.OrderBy(p => p.Nome).ToList();
                        ModelState.AddModelError("",
                            "Não existe atividade semestral ativa para o Tipo de Assunto selecionado.");
                        return View(solicitacaoViewModel);
                    }

                    var v_GuidUser = User.Identity.GetUserId();

                    var v_Solicitacao = new Solicitacao
                    {
                        AtividadeSemestralId =
                            v_AtividadeSemestral.Id,
                        DataCadastro = DateTime.Now,
                        Situacao = SituacaoEnum.Criado,
                        UsuarioCliente = db.Users.Where(p => p.Id == v_GuidUser).FirstOrDefault(),
                        Descricao = solicitacaoViewModel.Descricao,
                        Duvida = solicitacaoViewModel.Duvida,
                        IdentificacaoPartes = solicitacaoViewModel.IdentificacaoPartes,
                        FatoCotidianoId = solicitacaoViewModel.IdFatoCotidiano
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
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var solicitacao = db.Solicitacaos.Find(id);
            if (solicitacao == null)
                return HttpNotFound();

            var v_Role = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db)).FindByName("Monitor");

            var v_SolicitacaoEdicaoViewModel = new SolicitacaoEdicaoViewModel
            {
                Id = id.Value,
                FatoCotidiano = solicitacao.FatoCotidiano.Nome,
                IdentificacaoPartes = solicitacao.IdentificacaoPartes,
                Situacao = solicitacao.Situacao,
                DataCadastro = solicitacao.DataCadastro,
                Duvida = solicitacao.Duvida,
                Descricao = solicitacao.Descricao,
                Parecer = solicitacao.Parecer,
                Fundamentacao = solicitacao.Fundamentacao,
                Correcao = solicitacao.Correcao,
                Monitores = db.Users.Where(p => p.Roles.Any(r => r.RoleId == v_Role.Id)).ToList()
            };

            return View(v_SolicitacaoEdicaoViewModel);
        }

        // POST: Solicitacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor, Monitor")]
        public ActionResult Edit(SolicitacaoEdicaoViewModel p_SolicitacaoEdicaoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Solicitacao v_Solicitacao = db.Solicitacaos.Find(p_SolicitacaoEdicaoViewModel.Id);
                    v_Solicitacao.Fundamentacao = p_SolicitacaoEdicaoViewModel.Fundamentacao;
                    v_Solicitacao.Parecer = p_SolicitacaoEdicaoViewModel.Parecer;
                    v_Solicitacao.Correcao = p_SolicitacaoEdicaoViewModel.Correcao;

                    if (Request.Form["EnviarMonitor"] != null)
                    {
                        v_Solicitacao.Situacao = SituacaoEnum.EmAnalise;
                        v_Solicitacao.UsuarioAlunoId = p_SolicitacaoEdicaoViewModel.GuidMonitor;
                    }
                    else if (Request.Form["EnviarCliente"] != null)
                    {
                        v_Solicitacao.Situacao = SituacaoEnum.Respondido;
                        v_Solicitacao.UsuarioAluno = null;
                    }

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

            return View(p_SolicitacaoEdicaoViewModel);
        }

        // GET: Solicitacaos/Delete/5
        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var solicitacao = db.Solicitacaos.Find(id);
            if (solicitacao == null)
                return HttpNotFound();
            return View(solicitacao);
        }

        // POST: Solicitacaos/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor")]
        public ActionResult DeleteConfirmed(int id)
        {
            var solicitacao = db.Solicitacaos.Find(id);
            db.Solicitacaos.Remove(solicitacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }


    internal class CadastroEntities
    {
    }
}