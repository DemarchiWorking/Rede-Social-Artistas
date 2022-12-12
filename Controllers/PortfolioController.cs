using ArtCulture.Models;
using ArtCulture.Service;
using ArtCulture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArtCulture.Controllers
{
    [Route("[controller]")]
    public class PortfolioController : Controller
    {
        List<Portfolio> listaPortfolio = new List<Portfolio>();
        private readonly IPortfolioService _portfolioService;
        public PortfolioController(
            IPortfolioService portfolioService
            )
        {
            _portfolioService = portfolioService;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Portfolio/Portfolio")]
        public IActionResult Portfolio()
        {
            return View();
        }

        [HttpGet("Portfolio/CadastrarPortfolio")]
        public IActionResult CadastrarPortfolio()
        {
            return View();
        }
        [HttpGet("Portfolio/Produto")]
        public IActionResult Produto()
        {
            return View();
        }
        [HttpGet("Portfolio/Servico")]
        public IActionResult Servico()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }


        [HttpGet("CadastrarPortfolio")]
        public ActionResult CadastrarAmigo()
        {
            return View();
        }

        [HttpPost("Portfolio/Portfolio/CadastrarPortfolio")]
        public ActionResult CadastrarPortfolio(Portfolio portfolio)
        {
            var resposta = _portfolioService.CadastrarPortfolio(portfolio);
            return Redirect("/Portfolio/Portfolio/Portfolio");
            //return View(portfolio);
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            var resposta = _portfolioService.CadastrarProduto(produto);
            return View(produto);
        }

        [HttpPost]
        public ActionResult CadastrarServico(Servico servico)
        {
            var resposta = _portfolioService.CadastrarServico(servico);
            return View(servico);
        }

        [HttpGet("Portfolio/Portfolio/Listar")]
        public ActionResult ListaPortfolio(Portfolio portfolio)
        {
            var resposta = _portfolioService.CadastrarPortfolio(portfolio);
            return Redirect("/Portfolio/Portfolio/Portfolio");
        }

        [HttpGet("Portfolio/Produto/Listar")]
        public ActionResult ListaProduto(Produto produto)
        {
            var resposta = _portfolioService.CadastrarProduto(produto);
            return View(produto);
        }

        [HttpGet("Portfolio/Servico/Listar")]
        public ActionResult ListarServico(Servico servico)
        {
            var resposta = _portfolioService.CadastrarServico(servico);
            return View(servico);
        }



    }
}
