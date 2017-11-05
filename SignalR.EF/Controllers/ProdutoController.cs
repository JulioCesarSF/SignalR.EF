using Microsoft.AspNet.SignalR;
using SignalR.EF.DAL;
using SignalR.EF.Hubs;
using SignalR.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.EF.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly BancoContext _ctx;

        public ProdutoController()
        {
            _ctx = new BancoContext();
        }

        #region GETs
        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _ctx.Produtos.ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult AtualizarTabela()
        {
            var lista = _ctx.Produtos.ToList();
            return PartialView("_tabelaProdutos", lista);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
        #endregion

        #region POSTs
        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _ctx.Produtos.Add(produto);
                _ctx.SaveChanges();                
                Push();
            }
            else
            {
                TempData["msg"] = "Dados incorretos.";
                return View(produto);
            }

            TempData["msg"] = produto.Nome + " cadastrado com sucesso!";
            return RedirectToAction("Cadastrar");
        }
        #endregion

        public void Push()
        {
            var hubCtx = GlobalHost.ConnectionManager.GetHubContext<ProdutoHub>();
            hubCtx.Clients.All.NotificarClientes();            
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _ctx.Dispose();
        }
    }
}