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
    public interface IRepositoryForm
    {
        Task<ElementoDependente> TestarForm(string id);
        Formulario RetornaFormulario(Elemento elemento);
    }



    public class RepositoryForm : BaseRepository<Video>, IRepositoryForm
    {

        public RepositoryForm(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Formulario RetornaFormulario(Elemento elemento)
        {
            var f = (Formulario)elemento;
            var formulario = new Formulario
            {
                Pagina_ = elemento.Pagina_,
                Id = elemento.Id,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = f.ElementosDependentes,
                Dependentes = f.Dependentes
            };
            return formulario;
        }

        public async Task<ElementoDependente> TestarForm(string id)
        {
            Formulario formulario;
            try
            {
                formulario = await contexto.Elemento.
               OfType<Formulario>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));

            }
            catch (Exception)
            {
                formulario = null;
            }
            return formulario;
        }
    }
}