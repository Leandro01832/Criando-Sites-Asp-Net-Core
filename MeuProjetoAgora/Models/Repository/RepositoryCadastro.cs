using Microsoft.AspNetCore.Identity;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuProjetoAgora.business;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryCadastro
    {
        Task<Cadastro> UpdateAsync(int idCadastro, Cadastro cadastro);
    }



    public class RepositoryCadastro : BaseRepository<Cadastro>, IRepositoryCadastro
    {

        public RepositoryCadastro(IConfiguration configuration, ApplicationDbContext contexto)
            : base(configuration, contexto)
        {
            
        }

        public async Task<Cadastro> UpdateAsync(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = dbSet.Where(c => c.IdCadastro == cadastroId)
                .SingleOrDefault();

            if (cadastroDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDB.Update(novoCadastro);
            await contexto.SaveChangesAsync();
            return cadastroDB;
        }
    }
}
