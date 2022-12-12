using ArtCulture.Models;

namespace ArtCulture.Service.Interfaces
{
    public interface IUsuarioService
    {
        bool? CadastrarUsuario(Usuario usuario);
        Resposta<Usuario> LoginValidar(Usuario usuario);

    }
}
