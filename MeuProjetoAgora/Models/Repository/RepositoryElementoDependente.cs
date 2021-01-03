
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.business.Elemento;
using MeuProjetoAgora.Models.Join;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
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
                .FirstAsync(e => e.ElementoDependente.Dependente.IdElemento
                == dependente.ElementoDependente.Dependente.IdElemento &&
                e.Elemento.IdElemento
                == dependente.Elemento.IdElemento);
            }
            catch (Exception)
            {
                depe = null;
            }
            return depe;
        }
    }
}
