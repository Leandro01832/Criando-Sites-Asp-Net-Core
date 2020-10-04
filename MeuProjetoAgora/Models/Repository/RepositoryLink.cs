
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.Repository;
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
    public interface IRepositoryLink
    {
        Task<string> salvarLink(ViewModelElemento elemento, IList<IFormFile> files);
        Task editarLink(ViewModelElemento elemento);
        Task apagarLink(ViewModelElemento elemento);
    }



    public class RepositoryLink : BaseRepository<Link>, IRepositoryLink
    {

        public RepositoryLink(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Task apagarLink(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task editarLink(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public async Task<string> salvarLink(ViewModelElemento elemento, IList<IFormFile> files)
        {
            Link link = new Link
            {
                div_ = elemento.div,
                imagem_ = elemento.imagemLink_,
                pagina_ = elemento.paginaDestinoLink_,
                texto_ = elemento.textoLink_,
                Url = elemento.UrlLink,
                TextoLink = elemento.TextoLink
            };


            try
            {
                await dbSet.AddAsync(link);
                await contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var erro = "Preencha o formulario corretamente" + ex;
                return "";
            }

            var l = dbSet.Include(e => e.div).First(el => el.IdLink == link.IdLink);
            var element = new Elemento();
            element.link_ = link.IdLink;
            await contexto.Elemento.AddAsync(element);
             await contexto.SaveChangesAsync();

            if (elemento.Renderizar)
            {
                element.div_2 = link.div.IdDiv;
                contexto.Entry(element).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
            }

            return $"Chave do elemento: {element.IdElemento}";
        }
    }
}
