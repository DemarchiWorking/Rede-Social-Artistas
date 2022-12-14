using ArtCulture.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AniversarioReentregaPA.Repositorio
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly string _stringConexao;
        private readonly SqlConnection _conexao;

        public PortfolioRepository(
            IConfiguration configuration)
        {
            _stringConexao = configuration.GetConnectionString("conexaoSQL");
            _conexao = new SqlConnection(_stringConexao);
        } 
        public Resposta<Portfolio> CadastrarPortfolio(Portfolio portfolio, Usuario usuarioLogado)
        {
            try
            {
                DateTime data = DateTime.Now;
                string sql = $@"INSERT INTO PORTIFOLIO (ID_USUARIO, TITULO, DESCRICAO, FOTO, CRIACAO) VALUES({usuarioLogado.Id},'{portfolio.Titulo}','{portfolio.Descricao}', '{portfolio.Foto}', CAST('{data.ToString("yyyy-MM-dd")}' as datetime))"; 
                var resultado = _conexao.Execute(sql);

                Resposta<Portfolio> resposta = new Resposta<Portfolio>();

                if(resultado != 0)
                {
                    resposta.Status = 200;
                    resposta.Titulo = "Portfolio cadastrado com sucesso.";
                    return resposta;
                }
                else
                {
                    return null;
                }

            }catch(Exception e)
            {
                return null;
            }
        }

        public Resposta<Produto> CadastrarProduto(Produto produto)
        {
            try
            {
                
                string sql = $@"INSERT INTO PRODUTO (ID, ID_USUARIO, NOME, DESCRICAO, FOTO) VALUES('{produto.Id}','{produto.Id_Usuario}','{produto.Nome}', '{produto.Descricao}, '{produto.Foto}'";
                var resultado = _conexao.Execute(sql);

                Resposta<Produto> resposta = new Resposta<Produto>();

                if (resultado != 0)
                {
                    resposta.Status = 200;
                    resposta.Titulo = "Produto cadastrado com sucesso.";
                    resposta.Resultado.Append(produto);
                    return resposta;
                }
                else
                {
                    return null;
                }

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
                string sql = $@"INSERT INTO SERVICO (ID, ID_USUARIO, NOME, DESCRICAO, VALOR) VALUES('{servico.Id}', '{servico.Id_Usuario}', '{servico.Nome}','{servico.Descricao}', '{servico.Valor}'";
                var resultado = _conexao.Execute(sql);

                Resposta<Servico> resposta = new Resposta<Servico>();


                if (resultado != 0)
                {
                    resposta.Status = 200;
                    resposta.Titulo = "Produto cadastrado com sucesso.";
                    resposta.Resultado.Append(servico);
                    return resposta;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }


        public Resposta<Portfolio> ListarPortifolio()
        {
            try
            {
                string sql = $@"                  
                               SELECT ID, ID_USUARIO,TITULO,DESCRICAO,FOTO,CRIACAO FROM PORTIFOLIO ORDER BY CRIACAO;";



                var result = _conexao.Query<Portfolio>(sql);

                if (result != null && result.ToList().Count > 0)
                {
                    List<Portfolio> list = new List<Portfolio>();

                    result.ToList<dynamic>().ForEach(it =>
                    {
                        list.Add(new Portfolio
                        {
                            Id = Convert.ToInt32(it.Id),
                            Titulo = Convert.ToString(it.Titulo),
                            Descricao = Convert.ToString(it.Descricao),
                            Foto = Convert.ToString(it.Foto)
                        });
                    });

                    return new Resposta<Portfolio>()
                    {
                        Resultado = list,
                        Status = 200
                    };
                }
                else
                {
                    return new Resposta<Portfolio>()
                    {
                        Status = 0
                    };
                }
            }
            catch (Exception ex)
            {
                
            }

            return null;
        }

        public Resposta<int> ExcluirPortfolio(int Id)
        {
            try
            {
                string sql = $@"DELETE FROM PORTIFOLIO WHERE ID = {Id}";
                var resultado = _conexao.Execute(sql);

                Resposta<int> resposta = new Resposta<int>();

                if (resultado != 0)
                {
                    resposta.Status = 200;
                    resposta.Titulo = "Portfolio excluido com sucesso.";
                    return resposta;
                }
                else
                {
                    return null;
                }

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
                string sql = $@"SELECT ID, ID_USUARIO,TITULO,DESCRICAO,FOTO,CRIACAO FROM PORTIFOLIO WHERE ID = {Id};";



                var result = _conexao.Query<Portfolio>(sql);

                if (result != null && result.ToList().Count > 0)
                {
                    List<Portfolio> list = new List<Portfolio>();

                    result.ToList<dynamic>().ForEach(it =>
                    {
                        list.Add(new Portfolio
                        {
                            Id = Convert.ToInt32(it.Id),
                            Titulo = Convert.ToString(it.Titulo),
                            Descricao = Convert.ToString(it.Descricao),
                            Foto = Convert.ToString(it.Foto)
                        });
                    });

                    return new Resposta<Portfolio>()
                    {
                        Resultado = list,
                        Status = 200
                    };
                }
                else
                {
                    return new Resposta<Portfolio>()
                    {
                        Status = 0
                    };
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
            


        public Resposta<int> AlterarPortfolio(Portfolio portfolio)
        {
            try
            {
                string sql = $@"UPDATE PORTIFOLIO SET TITULO = '{portfolio.Titulo}', DESCRICAO = '{portfolio.Descricao}', FOTO = '{portfolio.Foto}' WHERE Id = {portfolio.Id};";
                var resultado = _conexao.Execute(sql);

                Resposta<int> resposta = new Resposta<int>();

                if (resultado != 0)
                {
                    resposta.Status = 200;
                    resposta.Titulo = "Portfolio alterado com sucesso.";
                    return resposta;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
