using business.ecommerce;
using CMS.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
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
            var cadastroDB = dbSet.Where(c => c.Id == cadastroId)
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
