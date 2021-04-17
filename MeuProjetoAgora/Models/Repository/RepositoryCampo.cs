
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Data;
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
    public interface IRepositoryCampo
    {
        Task<Campo> TestarCampo(string id);
        Campo RetornaCampo(Elemento elemento);
    }



    public class RepositoryCampo : BaseRepository<Campo>, IRepositoryCampo
    {

        public RepositoryCampo(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Campo RetornaCampo(Elemento elemento)
        {
            var c = (Campo)elemento;
            var campo = new Campo
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                Placeholder = c.Placeholder,
                TipoCampo = c.TipoCampo,
                ElementosDependentes = c.ElementosDependentes,
                Despendentes = c.Despendentes

            };
            return campo;
        }

        public async Task<Campo> TestarCampo(string id)
        {
            Campo campo;
            try
            {
                campo = await contexto.Elemento.
               OfType<Campo>().FirstOrDefaultAsync(e => e.IdElemento == int.Parse(id));
            }
            catch (Exception)
            {
                campo = null;
            }
            return campo;
        }
    }
}
