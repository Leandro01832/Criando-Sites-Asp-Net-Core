
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryForm
    {
        Task<string> salvarForm(ViewModelElemento elemento, IList<IFormFile> files);
        Task editarForm(ViewModelElemento elemento);
        Task apagarForm(ViewModelElemento elemento);
    }



    public class RepositoryForm : BaseRepository<Video>, IRepositoryForm
    {

        public RepositoryForm(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Task apagarForm(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task editarForm(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task<string> salvarForm(ViewModelElemento elemento, IList<IFormFile> files)
        {
            throw new NotImplementedException();
        }
    }
}
