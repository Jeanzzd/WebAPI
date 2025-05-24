using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using WebAPI.Net.Data;
using WebAPI.Net.Models;
using WebAPI.Net.Repository.Interface;

namespace WebAPI.Net.Repository
{
    public class MotoRepository : IMotoRepository
    {

        private readonly dbContext dbContext;
        public MotoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Moto> AtualizarMoto(Moto moto)
        {
            var result = await dbContext.Motos.FirstOrDefaultAsync(x => x.MotoId == moto.MotoId);

            if (result != null)
            {
                result.MotoId = moto.MotoId;
                result.Ano = moto.Ano;
                result.Cor = moto.Cor;  
                result.Modelo = moto.Modelo;

                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Moto> CriarMoto(Moto moto)
        {
            var result = await dbContext.Motos.AddAsync(moto);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Moto> DeletarMoto(int id)
        {
            var result = await dbContext.Motos.FirstOrDefaultAsync(x => x.MotoId == id);
            if (result != null)
            {
                dbContext.Motos.Remove(result);
                await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Moto> GetMoto(int id)
        {
            return await dbContext.Motos.FirstOrDefaultAsync(x => x.MotoId == id);
        }

        public async Task<IEnumerable> GetMotos()
        {
            return await dbContext.Motos.ToListAsync();
        }

      
    }
}
