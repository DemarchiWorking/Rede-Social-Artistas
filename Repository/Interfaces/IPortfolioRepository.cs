using ArtCulture.Models;
using System.Collections.Generic;

namespace AniversarioReentregaPA.Repositorio
{
    public interface IPortfolioRepository
    {
        Resposta<Portfolio> CadastrarPortfolio(Portfolio portfolio, Usuario usuarioLogado);
        Resposta<Produto> CadastrarProduto(Produto produto);
        Resposta<Servico> CadastrarServico(Servico servico);

        Resposta<Portfolio> ListarPortifolio();
        Resposta<Portfolio> SelecionarPorId(int Id);
        Resposta<int> ExcluirPortfolio(int Id);

        Resposta<int> AlterarPortfolio(Portfolio portfolio);

    }
}
