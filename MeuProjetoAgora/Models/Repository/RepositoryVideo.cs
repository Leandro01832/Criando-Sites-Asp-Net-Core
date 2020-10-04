
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
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
        Task<string> salvarVideo(ViewModelElemento elemento, IList<IFormFile> files);
        Task editarVideo(ViewModelElemento elemento);
        Task apagarVideo(ViewModelElemento elemento);
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

        public Task apagarVideo(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task editarVideo(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public async Task<string> salvarVideo(ViewModelElemento elemento, IList<IFormFile> files)
        {
            string filename = ContentDispositionHeaderValue.Parse(files[0].ContentDisposition).FileName.ToString().Trim('"');

            var video = new Video()
            {
                ArquivoVideo = "",
                div_ = elemento.div
            };

            try
            {
               await dbSet.AddAsync(video);
               await contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "";
            }

            filename = this.EnsureCorrectFilename(filename, video.IdVideo);

            video.ArquivoVideo = "/VideosGaleria/" + filename;
            contexto.Entry(video).State = EntityState.Modified;
           await contexto.SaveChangesAsync();

            var el = new Elemento
            {
                video_ = video.IdVideo,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                Renderizar = elemento.Renderizar,
                div_2 = elemento.div 
            };

           await contexto.Elemento.AddAsync(el);
           await contexto.SaveChangesAsync();

            byte[] buffer = new byte[16 * 1024];

            using (FileStream output = System.IO.File.Create(this.GetPathAndFilenameArquivoVideo(filename, video.div_)))
            {
                using (Stream input = files[0].OpenReadStream())
                {
                    long totalReadBytes = 0;
                    int readBytes;

                    while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, readBytes);
                        totalReadBytes += readBytes;
                        //  await Task.Delay(10); // It is only to make the process slower
                    }
                }
            }

            return $"Chave do elemento: {el.IdElemento}";
        }

        
    }
}
