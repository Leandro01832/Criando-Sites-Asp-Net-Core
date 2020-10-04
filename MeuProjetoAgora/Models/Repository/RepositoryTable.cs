
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
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
        Task<string> salvarTable(ViewModelElemento elemento, IList<IFormFile> files);
        Task editarTable(ViewModelElemento elemento);
        Task apagarTable(ViewModelElemento elemento);
    }



    public class RepositoryTable : BaseRepository<Table>, IRepositoryTable
    {

        public RepositoryTable(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Task apagarTable(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task editarTable(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public async Task<string> salvarTable(ViewModelElemento elemento, IList<IFormFile> files)
        {
            Table table = new Table
            {
                div_ = elemento.div,
                Nome = elemento.Nome,
                Estilo = elemento.EstiloTable

            };


            try
            {
               await dbSet.AddAsync(table);
                await contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var erro = "Preencha o formulario corretamente" + ex;
                return "";
            }

            var t = dbSet.Include(ca => ca.div).First(c => c.IdTable == table.IdTable);
            var element = new Elemento();
            element.table_ = table.IdTable;
            await contexto.Elemento.AddAsync(element);
            await contexto.SaveChangesAsync();

            if (elemento.Renderizar)
            {
                element.div_2 = table.div.IdDiv;
                contexto.Entry(element).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
            }

            return $"Chave do elemento: {element.IdElemento}";
        }
    }
}
