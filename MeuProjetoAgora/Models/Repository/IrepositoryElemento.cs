using MeuProjetoAgora.business.Elementos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
   public interface IRepositoryElemento
    {
        Task<string> salvar(Elemento elemento);
        Task Editar(Elemento elemento);
        Task<List<Elemento>> TodosElementos();
        IIncludableQueryable<Elemento, Elemento> includes();
    }
}
