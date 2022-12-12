using ArtCulture.Models;
using System.Collections.Generic;

namespace ArtCulture.Repositorio
{
    public interface IUsuarioRepository
    {
        bool? CadastrarUsuario(Usuario usuario);
        Resposta<Usuario> LoginValidar(Usuario usuario);


    }
}
