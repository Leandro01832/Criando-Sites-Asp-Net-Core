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
    public interface IRepositoryTable
    {
        Task<ElementoDependente> TestarTable(string id);
        Table RetornaTable(Elemento elemento);
    }



    public class RepositoryTable : BaseRepository<Table>, IRepositoryTable
    {

        public RepositoryTable(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Table RetornaTable(Elemento elemento)
        {
            var t = (Table)elemento;
            var table = new Table
            {
                Pagina_ = elemento.Pagina_,
                Id = elemento.Id,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                EstiloTabela = t.EstiloTabela,
                ElementosDependentes = t.ElementosDependentes,
                Dependentes = t.Dependentes
            };
            return table;
        }

        public async Task<ElementoDependente> TestarTable(string id)
        {
            Table table;
            try
            {
                table = await contexto.Elemento.
               OfType<Table>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));

            }
            catch (Exception)
            {
                table = null;
            }
            return table;
        }
    }
}