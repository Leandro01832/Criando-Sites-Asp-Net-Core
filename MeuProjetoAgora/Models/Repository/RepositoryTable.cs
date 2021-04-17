
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
    public interface IRepositoryTable
    {
        Task<Table> TestarTable(string id);
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
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                EstiloTabela = t.EstiloTabela,
                ElementosDependentes = t.ElementosDependentes,
                Despendentes = t.Despendentes
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
