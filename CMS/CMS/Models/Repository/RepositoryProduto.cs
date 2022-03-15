using business.business.element;
using business.business.Elementos.element;
using business.business.Elementos.produto;
using CMS.Data;
using CMS.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryProduto
    {
        Task<Elemento> TestarProduto(string id);
        Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa);
        Task<bool> VerificaExistenciaElementoDependente(string id);
    }



    public class RepositoryProduto : BaseRepository<ProdutoDependente>, IRepositoryProduto
    {

        public RepositoryProduto(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public async Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa)
        {
            IQueryable<ProdutoDependente> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.Nome.Contains(pesquisa));
            }

            return new BuscaProdutosViewModel(await query.ToListAsync(), pesquisa);
        }        

        public async Task<Elemento> TestarProduto(string id)
        {
            ProdutoDependente produto;
            try
            {
                produto = await contexto.Elemento.
               OfType<ProdutoDependente>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
            }
            catch (Exception)
            {
                produto = null;
            }
            return produto;
        }

        public async Task<bool> VerificaExistenciaElementoDependente(string id)
        {
            ElementoDependente elementoDependente;
            try
            {
                elementoDependente = await contexto.ElementoDependente
                .FirstOrDefaultAsync(e => e.Id == int.Parse(id));
            }
            catch (Exception)
            {
                return true;
            }

            if (elementoDependente != null) return true;
            else
                return false;
        }
    }
}