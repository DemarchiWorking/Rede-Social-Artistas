using AniversarioReentregaPA.Repositorio;
using ArtCulture.Models;
using ArtCulture.Service.Interfaces;
using System;

namespace ArtCulture.Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public Resposta<Portfolio> CadastrarPortfolio(Portfolio portfolio)
        {
            try
            {
                return _portfolioRepository.CadastrarPortfolio(portfolio);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Resposta<Produto> CadastrarProduto(Produto produto)
        {
            try
            {
                return _portfolioRepository.CadastrarProduto(produto);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Resposta<Servico> CadastrarServico(Servico servico)
        {
            try
            {
                return _portfolioRepository.CadastrarServico(servico);
            }
            catch (Exception e)
            {
                return null;
            }
        }





        public Resposta<Portfolio> ListarPortfolio(Portfolio portfolio)
        {
            try
            {
                return _portfolioRepository.CadastrarPortfolio(portfolio);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Resposta<Produto> ListarProduto(Produto produto)
        {
            try
            {
                return _portfolioRepository.CadastrarProduto(produto);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Resposta<Servico> ListarServico(Servico servico)
        {
            try
            {
                return _portfolioRepository.CadastrarServico(servico);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}



