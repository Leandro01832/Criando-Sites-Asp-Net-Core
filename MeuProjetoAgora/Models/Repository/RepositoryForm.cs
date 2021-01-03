
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.business.Elemento;
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
    public interface IRepositoryForm
    {
        Task<Formulario> TestarForm(string id);
        Formulario RetornaFormulario(ViewModelElemento elemento);
    }



    public class RepositoryForm : BaseRepository<Video>, IRepositoryForm
    {

        public RepositoryForm(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Formulario RetornaFormulario(ViewModelElemento elemento)
        {
            var formulario = new Formulario
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = elemento.elementosDependentes,
                Despendentes = elemento.Dependentes
            };
            return formulario;
        }

        public async Task<Formulario> TestarForm(string id)
        {
            Formulario formulario;
            try
            {
                formulario = await contexto.Elemento.
               OfType<Formulario>().FirstOrDefaultAsync(e => e.IdElemento == int.Parse(id));

            }
            catch (Exception)
            {
                formulario = null;
            }
            return formulario;
        }
    }
}
