using System.Collections;
using WebAPI.Net.Models;

namespace WebAPI.Net.Repository.Interface
{
    public interface IMotoRepository
    {

        Task<IEnumerable> GetMotos();
        Task<Moto> GetMoto(int id);
        Task<Moto> DeletarMoto(int id);
        Task<Moto> CriarMoto(Moto moto);
        Task<Moto> AtualizarMoto(Moto moto);
    }
}
