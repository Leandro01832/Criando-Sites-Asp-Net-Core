
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
    public interface IRepositoryDropdown
    {
        Dropdown RetornaDropdown(Elemento elemento);
    }



    public class RepositoryDropdown : BaseRepository<Dropdown>, IRepositoryDropdown
    {

        public RepositoryDropdown(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Dropdown RetornaDropdown(Elemento elemento)
        {
            return new Dropdown
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = elemento.ElementosDependentes,
                Despendentes = elemento.Despendentes
            };
        }
    }
}
