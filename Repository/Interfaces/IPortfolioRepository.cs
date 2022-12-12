using ArtCulture.Models;
using System.Collections.Generic;

namespace AniversarioReentregaPA.Repositorio
{
    public interface IPortfolioRepository
    {
        Resposta<Portfolio> CadastrarPortfolio(Portfolio portfolio);
        Resposta<Produto> CadastrarProduto(Produto produto);
        Resposta<Servico> CadastrarServico(Servico servico);

    }
}
