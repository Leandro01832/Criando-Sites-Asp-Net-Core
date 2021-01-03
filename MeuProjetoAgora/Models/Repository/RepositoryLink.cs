
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.business.Elemento;
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

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryLink
    {
        IIncludableQueryable<Link, Elemento> includes();
        Task<Link> TestarLink(string id);
        Link RetornaLink(ViewModelElemento elemento);
    }



    public class RepositoryLink : BaseRepository<Link>, IRepositoryLink
    {

        public RepositoryLink(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public IIncludableQueryable<Link, Elemento> includes()
        {
            var l2 = contexto.Link
                .Include(e => e.Destino)
                .Include(e => e.div)
                .ThenInclude(e => e.Div)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pedido)
                .Include(e => e.div)
                .ThenInclude(e => e.Elemento)
                .Include(e => e.Despendentes)
                .ThenInclude(e => e.ElementoDependente)
                .ThenInclude(e => e.Dependente);

            return l2;
        }

        public Link RetornaLink(ViewModelElemento elemento)
        {
            var link = new Link
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                Menu = elemento.Menu,
                paginaDestinoLink_ = elemento.paginaDestinoLink_,
                TextoLink = elemento.TextoLink,
                UrlLink = elemento.UrlLink,
                ElementosDependentes = elemento.elementosDependentes,
                Despendentes = elemento.Dependentes
            };
            return link;
        }

        public async Task<Link> TestarLink(string id)
        {
            Link link;
            try
            {
                link = await contexto.Elemento.
               OfType<Link>().FirstOrDefaultAsync(e => e.IdElemento == int.Parse(id));
            }
            catch (Exception)
            {
                link = null;
            }
            return link;
        }
    }
}
