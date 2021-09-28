using business.business.element;
using business.business.Elementos.element;
using business.business.Elementos.texto;
using business.Join;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryTexto
    {
        Task<ElementoDependente> TestarTexto(string id);
        Texto RetornaTexto(Elemento elemento);
    }



    public class RepositoryTexto : BaseRepository<Texto>, IRepositoryTexto
    {

        public RepositoryTexto(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Texto RetornaTexto(Elemento elemento)
        {
            var t = (Texto)elemento;
            return new Texto
            {
                Pagina_ = elemento.Pagina_,
                Id = elemento.Id,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                PalavrasTexto = t.PalavrasTexto
            };
        }

        public async Task<ElementoDependente> TestarTexto(string id)
        {
            Elemento elemento;
            try
            {
                elemento = await contexto.ElementoComum.
               OfType<Texto>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
                if (elemento != null)
                {
                    var texto = new TextoDependente
                    {
                        Dependentes = new List<ElementoDependenteElemento>(),
                        ElementosDependentes = "",
                        div = elemento.div,
                        Nome = elemento.Nome,
                        Ordem = elemento.Ordem,
                        Pagina_ = elemento.Pagina_,
                        tipo = elemento.tipo
                    };
                    await contexto.TextoDependente.AddAsync(texto);
                    await contexto.SaveChangesAsync();
                    return texto;
                }
                elemento = await contexto.ElementoDependente.
               OfType<Texto>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
            }
            catch (Exception)
            {
                elemento = null;
            }
            return (ElementoDependente) elemento;
        }
    }
}