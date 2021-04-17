
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
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
        Task<Texto> TestarTexto(string id);
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
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                PalavrasTexto = t.PalavrasTexto,
                ElementosDependentes = elemento.ElementosDependentes,
                Despendentes = elemento.Despendentes
            };
        }

        public async  Task<Texto> TestarTexto(string id)
        {
            Texto texto;
            try
            {
                texto = await contexto.Elemento.
               OfType<Texto>().FirstOrDefaultAsync(e => e.IdElemento == int.Parse(id));

            }
            catch (Exception)
            {
                texto = null;
            }
            return texto;
        }
    }
}
