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
        public Resposta<Portfolio> CadastrarPortfolio(Portfolio portfolio)
        {
            try
            {
                DateTime data = DateTime.Now;
                string sql = $@"INSERT INTO PORTIFOLIO (ID_USUARIO, TITULO, DESCRICAO, FOTO, CRIACAO) VALUES(1,'{portfolio.Id}','{portfolio.Descricao}', '{portfolio.Foto}', CAST('{data.ToString("yyyy-MM-dd")}' as datetime))"; 
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
                               SELECT * FROM 



                var result = _connection.Query<dynamic>(sql);

                if (result != null && result.ToList().Count > 0)
                {
                    List<CountTweetPerTagAndLang> list = new List<CountTweetPerTagAndLang>();

                    result.ToList<dynamic>().ForEach(it =>
                    {
                        list.Add(new CountTweetPerTagAndLang
                        {
                            tag = Convert.ToString(it.TAG),
                            lang = Convert.ToString(it.LANG),
                            count = Convert.ToInt32(it.COUNT)
                        });
                    });

                    return new Response()
                    {
                        List = list,
                        isSuccess = true
                    };
                }
                else if (result != null && result.ToList().Count == 0)
                {
                    return new Response()
                    {
                        isEmpty = true,
                        isSuccess = true
                    };

                }
                else
                {
                    return new Response()
                    {
                        isSuccess = false
                    };
                }
            }
            catch (Exception ex)
            {
                
            }

            return null;
        }


    }
}
