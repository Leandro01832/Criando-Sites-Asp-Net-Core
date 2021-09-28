using business.business.element;
using business.business.Elementos.element;
using business.business.link;
using business.Join;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryLink
    {
        IIncludableQueryable<Link, Elemento> includes();
        Task<ElementoDependente> TestarLink(string id);
    }



    public class RepositoryLink : BaseRepository<Link>, IRepositoryLink
    {

        public RepositoryLink(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public IIncludableQueryable<Link, Elemento> includes()
        {
            var l2 = contexto.Link
                .Include(e => e.Pagina)
                .Include(e => e.div)
                .ThenInclude(e => e.Div)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pedido)
                .Include(e => e.div)
                .ThenInclude(e => e.Elemento);

            return l2;
        }

       

        public async Task<ElementoDependente> TestarLink(string id)
        {
            Elemento elemento;
            try
            {
                elemento = await contexto.ElementoComum.
               OfType<Link>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
                if (elemento != null)
                {
                    var link = new LinkMenu
                    {
                        Dependentes = new List<ElementoDependenteElemento>(),
                        ElementosDependentes = "",
                        div = elemento.div,
                        Nome = elemento.Nome,
                        Ordem = elemento.Ordem,
                        Pagina_ = elemento.Pagina_,
                        tipo = elemento.tipo
                    };
                    await contexto.LinkMenu.AddAsync(link);
                    await contexto.SaveChangesAsync();
                    return link;
                }
                elemento = await contexto.ElementoDependente.
               OfType<Link>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
            }
            catch (Exception)
            {
                elemento = null;
            }
            return (ElementoDependente) elemento;
        }
    }
}