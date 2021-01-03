
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
    public interface IRepositoryTable
    {
        Task<Table> TestarTable(string id);
        Table RetornaTable(ViewModelElemento elemento);
    }



    public class RepositoryTable : BaseRepository<Table>, IRepositoryTable
    {

        public RepositoryTable(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Table RetornaTable(ViewModelElemento elemento)
        {
            var table = new Table
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                EstiloTabela = elemento.EstiloTabela,
                ElementosDependentes = elemento.elementosDependentes,
                Despendentes = elemento.Dependentes
            };
            return table;
        }

        public async Task<Table> TestarTable(string id)
        {
            Table table;
            try
            {
                table = await contexto.Elemento.
               OfType<Table>().FirstOrDefaultAsync(e => e.IdElemento == int.Parse(id));

            }
            catch (Exception)
            {
                table = null;
            }
            return table;
        }
    }
}
