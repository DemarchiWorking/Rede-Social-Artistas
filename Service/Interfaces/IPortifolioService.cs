using ArtCulture.Models;

namespace ArtCulture.Service.Interfaces
{
    public interface IPortfolioService
    {
        Resposta<Servico> CadastrarServico(Servico servico);
        Resposta<Produto> CadastrarProduto(Produto produto);
        Resposta<Portfolio> CadastrarPortfolio(Portfolio portfolio, Usuario usuarioLogado);
        Resposta<Portfolio> ListarPortfolio();
        Resposta<Produto> ListarProduto(Produto produto);
        Resposta<Servico> ListarServico(Servico servico);
        Resposta<int> ExcluirPortfolio(int Id);
        Resposta<Portfolio> SelecionarPorId(int Id);

        Resposta<int> AlterarPortfolio(Portfolio portfolio);
    }
}
