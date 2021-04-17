
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Models.Repository;
using MeuProjetoAgora.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryProduto
    {
        Task<Produto> TestarProduto(string id);
        Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa);
        Produto RetornaProduto(Elemento elemento);
        Task<bool> VerificaExistenciaElementoDependente(string id);
    }



    public class RepositoryProduto : BaseRepository<Produto>, IRepositoryProduto
    {

        public RepositoryProduto(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public async Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa)
        {
            IQueryable<Produto> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.Nome.Contains(pesquisa));
            }

            return new BuscaProdutosViewModel(await query.ToListAsync(), pesquisa);
        }

        public Produto RetornaProduto(Elemento elemento)
        {
            var p = (Produto)elemento;
            var produto = new Produto
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                Descricao = p.Descricao,
                estoque = p.estoque,
                Preco = p.Preco,
                ElementosDependentes = p.ElementosDependentes,
                Despendentes = p.Despendentes,
                Segmento = p.Segmento,
                Codigo = p.Codigo

            };
            return produto;
        }

        public async Task<Produto> TestarProduto(string id)
        {
            Produto produto;
            try
            {
                produto = await contexto.Elemento.
               OfType<Produto>().FirstOrDefaultAsync(e => e.IdElemento == int.Parse(id));
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
              .Include(e => e.Dependente)
              .FirstOrDefaultAsync(e => e.Dependente.IdElemento == int.Parse(id));
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
