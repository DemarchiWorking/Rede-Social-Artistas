using ArtCulture.Models;
using ArtCulture.Repositorio;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArtCulture.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _stringConexao;
        private readonly SqlConnection _conexao;

        public UsuarioRepository(
            IConfiguration configuration)
        {
            _stringConexao = configuration.GetConnectionString("conexaoSQL");
            _conexao = new SqlConnection(_stringConexao);
        } 
        public bool? CadastrarUsuario(Usuario usuario)
        {
            try
            {
                string sql = $@"INSERT INTO Usuario (Nome, Email, Senha, Profissao, Telefone) VALUES('{usuario.Nome}','{usuario.Email}', '{usuario.Senha}', '{usuario.Profissao}', '{usuario.Tefone}')"; 
                var resultado = _conexao.Execute(sql);

                if(resultado != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }catch(Exception e)
            {
                return null;
            }
        }

        public Resposta<Usuario> LoginValidar(Usuario usuario)
        {

            string sql = $"SELECT ID, NOME, EMAIL, SENHA, PROFISSAO, TELEFONE FROM USUARIO WHERE EMAIL='{usuario.Email}' AND SENHA='{usuario.Senha}'";

            var resultado = _conexao.Query<Usuario>(sql);


            Resposta<Usuario> resposta = new Resposta<Usuario>();

            if (resultado != null && resultado.ToList().Count > 0)
            {
                resposta.Titulo = "Login Ok";
                resposta.Status = 200;
                resposta.Resultado = resultado;

                return resposta;
                
            }
            return resposta;
        }


    }
}
