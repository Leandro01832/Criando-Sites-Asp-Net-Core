
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
    public interface IRepositoryTexto
    {
        Task<string> salvarTexto(ViewModelElemento elemento, IList<IFormFile> files);
        Task editarTexto(ViewModelElemento elemento);
        Task apagarTexto(ViewModelElemento elemento);
    }



    public class RepositoryTexto : BaseRepository<Texto>, IRepositoryTexto
    {

        public RepositoryTexto(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Task apagarTexto(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task editarTexto(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public async Task<string> salvarTexto(ViewModelElemento elemento, IList<IFormFile> files)
        {
            Texto texto = new Texto
            {
                div_ = elemento.div,
                Nome = elemento.Nome,
                Palavras = elemento.PalavrasTexto
            };


            try
            {
                await dbSet.AddAsync(texto);
                await contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var erro = "Preencha o formulario corretamente" + ex;
                return "";
            }

            var t = dbSet.Include(te => te.div).First(te => te.IdTexto == texto.IdTexto);
            var element = new Elemento();
            element.texto_ = texto.IdTexto;
           await contexto.Elemento.AddAsync(element);
             await contexto.SaveChangesAsync();

            if (elemento.Renderizar)
            {
                element.div_2 = texto.div.IdDiv;
                contexto.Entry(element).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
            }

            return $"Chave do elemento: {element.IdElemento}";
        }
    }
}
