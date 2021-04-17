
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryVideo
    {
        Task<string> salvarVideo(Elemento elemento);
        Task editarVideo(Elemento elemento);
        Task apagarVideo(Elemento elemento);
        string EnsureCorrectFilename(string filename, int Id);
    }



    public class RepositoryVideo : BaseRepository<Video>, IRepositoryVideo
    {
        public IHostingEnvironment HostingEnvironment { get; }

        public RepositoryVideo(IConfiguration configuration, ApplicationDbContext contexto,
             IHostingEnvironment hostingEnvironment) : base(configuration, contexto)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public string EnsureCorrectFilename(string filename, int Id)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return Id + "-" + filename;
        }

        private string GetPathAndFilenameArquivoVideo(string filename, int Id)
        {
            string path = this.HostingEnvironment.WebRootPath + "\\VideosGaleria\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }

        public Task apagarVideo(Elemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task editarVideo(Elemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task<string> salvarVideo(Elemento elemento)
        {
            throw new NotImplementedException();
        }

        
    }
}
