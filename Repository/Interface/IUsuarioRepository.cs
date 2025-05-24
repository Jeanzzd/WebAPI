using System.Collections;
using WebAPI.Net.Models;

namespace WebAPI.Net.Repository.Interface
{
    public interface IUsuarioRepository
    {

        Task<IEnumerable> GetUsuarios();
        Task<Usuario> GetUsuarios(int id);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario);
        Task<Usuario> DeletarUsuario(int id);
    }
}
