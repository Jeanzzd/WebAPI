using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebAPI.Net.Data;
using WebAPI.Net.Models;
using WebAPI.Net.Repository.Interface;

namespace WebAPI.Net.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly dbContext dbContext;

        public UsuarioRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            var result = await dbContext.Usuarios.AddAsync(usuario);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario)
        {
            var result = await dbContext.Usuarios.FirstOrDefaultAsync(x => x.UserId == usuario.UserId);

            if (result != null)
            {   
                result.UserId = usuario.UserId;
                result.Nome = usuario.Nome;
                result.Cpf = usuario.Cpf;   
                result.Email = usuario.Email;   

                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Usuario> DeletarUsuario(int id)
        {
            var result = await dbContext.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);
            if (result != null)
            {
                dbContext.Usuarios.Remove(result);
                await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable> GetUsuarios()
        {
            return await dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarios(int id)
        {
            return await dbContext.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
