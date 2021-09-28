using business.business.element;
using business.business.Elementos;
using business.business.Elementos.element;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryCampo
    {
        Task<ElementoComum> TestarCampo(string id);
        Campo RetornaCampo(Elemento elemento);
    }



    public class RepositoryCampo : BaseRepository<Campo>, IRepositoryCampo
    {

        public RepositoryCampo(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Campo RetornaCampo(Elemento elemento)
        {
            Campo c = (Campo)elemento;
            var campo = new Campo
            {
                Pagina_ = elemento.Pagina_,
                Id = elemento.Id,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                Placeholder = c.Placeholder,
                TipoCampo = c.TipoCampo,
                TableId = c.TableId,
                div = c.div,
                Table = c.Table
            };
            return campo;
        }

        public async Task<ElementoComum> TestarCampo(string id)
        {
            Campo campo;
            try
            {
                campo = await contexto.Elemento.
               OfType<Campo>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
            }
            catch (Exception)
            {
                campo = null;
            }
            return campo;
        }
    }
}