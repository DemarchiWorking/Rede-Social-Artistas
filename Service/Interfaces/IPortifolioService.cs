using ArtCulture.Models;

namespace ArtCulture.Service.Interfaces
{
    public interface IPortfolioService
    {
        Resposta<Servico> CadastrarServico(Servico servico);
        Resposta<Produto> CadastrarProduto(Produto produto);
        Resposta<Portfolio> CadastrarPortfolio(Portfolio portfolio);
    }
}
