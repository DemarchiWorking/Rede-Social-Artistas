using ArtCulture.Models;
using ArtCulture.Repositorio;
using ArtCulture.Service.Interfaces;
using System;

namespace ArtCulture.Service
{
    public class UsuarioService : IUsuarioService
    {
        //private readonly ILogger _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(
            IUsuarioRepository usuarioRepository
            )
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool? CadastrarUsuario(Usuario usuario)
        {
            try
            {
                var resposta = _usuarioRepository.CadastrarUsuario(usuario);

                return resposta;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Resposta<Usuario> LoginValidar(Usuario usuario)
        {
            return _usuarioRepository.LoginValidar(usuario);
        }
    }
}
