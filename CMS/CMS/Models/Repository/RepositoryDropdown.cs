using System;
using System.Linq;
using System.Threading.Tasks;
using business.business.element;
using business.business.Elementos;
using business.business.Elementos.element;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CMS.Models.Repository
{
    public interface IRepositoryDropdown
    {
        Task<Dropdown> RetornaDropdown(Elemento elemento);
        Task<ElementoDependente> TestarDropdown(string id);
    }



    public class RepositoryDropdown : BaseRepository<Dropdown>, IRepositoryDropdown
    {

        public RepositoryDropdown(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Dropdown RetornaDropdown(Elemento elemento)
        {
            var d = (Dropdown)elemento;
            return new Dropdown
            {
                Pagina_ = elemento.Pagina_,
                Id = elemento.Id,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = d.ElementosDependentes,
                Dependentes = d.Dependentes
            };
        }

        public async Task<ElementoDependente> TestarDropdown(string id)
        {
            Dropdown Dropdown;
            try
            {
                Dropdown = await contexto.Elemento.
               OfType<Dropdown>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
            }
            catch (Exception)
            {
                Dropdown = null;
            }
            return Dropdown;
        }

        Task<Dropdown> IRepositoryDropdown.RetornaDropdown(Elemento elemento)
        {
            throw new System.NotImplementedException();
        }
    }
}