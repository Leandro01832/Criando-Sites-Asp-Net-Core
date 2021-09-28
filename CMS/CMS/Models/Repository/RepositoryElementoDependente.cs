
using business.business.element;
using business.Join;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryElementoDependente
    {
        Task<ElementoDependenteElemento> TestarElementoDependenteElemento(ElementoDependenteElemento dependente);
    }



    public class RepositoryElementoDependente : BaseRepository<ElementoDependente>, IRepositoryElementoDependente
    {

        public RepositoryElementoDependente(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public async Task<ElementoDependenteElemento> TestarElementoDependenteElemento(ElementoDependenteElemento dependente)
        {
            ElementoDependenteElemento depe;
            try
            {
                depe = await contexto.ElementoDependenteElemento
                    .Include(e => e.Elemento)
                    .Include(e => e.ElementoDependente)
                .FirstAsync(e => e.ElementoDependente.Id
                == dependente.ElementoDependente.Id &&
                e.Elemento.Id
                == dependente.Elemento.Id);
            }
            catch (Exception)
            {
                depe = null;
            }
            return depe;
        }
    }
}
