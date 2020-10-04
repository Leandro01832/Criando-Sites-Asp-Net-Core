using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
   public interface IRepositoryElemento
    {
        Task<string> salvar(ViewModelElemento elemento , IList<IFormFile> files);
        Task Editar(ViewModelElemento elemento);
        Task Apagar(ViewModelElemento elemento);
        Task Ler(int? DivId);

    }
}
