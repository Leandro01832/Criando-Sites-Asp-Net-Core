using business.business.Elementos;
using business.business.Elementos.element;
using CMS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CMS.Models.Repository
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
