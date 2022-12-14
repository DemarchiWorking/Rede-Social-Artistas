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

        public Resposta<Portfolio> CadastrarPortfolio(Portfolio portfolio, Usuario usuarioLogado)
        {
            try
            {
                return _portfolioRepository.CadastrarPortfolio(portfolio, usuarioLogado);
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

        public Resposta<Portfolio> ListarPortfolio()
        {
            try
            {
                return _portfolioRepository.ListarPortifolio();
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

        public Resposta<int> ExcluirPortfolio(int Id)
        {
            try
            {
                return _portfolioRepository.ExcluirPortfolio(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Resposta<Portfolio> SelecionarPorId(int Id)
        {
            try
            {
                return _portfolioRepository.SelecionarPorId(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Resposta<int> AlterarPortfolio(Portfolio portfolio) 
        {
            try
            {
                return _portfolioRepository.AlterarPortfolio(portfolio);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}



