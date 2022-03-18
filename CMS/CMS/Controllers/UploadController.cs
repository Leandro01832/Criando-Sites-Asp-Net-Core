using business.business.Elementos;
using business.business.Elementos.imagem;
using CMS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class UploadController : Controller
    {
        public ApplicationDbContext db { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public UploadController(ApplicationDbContext Db, IHostingEnvironment hostingEnvironment)
        {
            db = Db;
            HostingEnvironment = hostingEnvironment;
        }

        
        private string GetPathAndFilenameArquivoVideo(string filename)
        {
            string path = this.HostingEnvironment.WebRootPath + "\\VideosGaleria\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }

        private string GetPathAndFilenameArquivoMusica(string filename, int Id)
        {
            string path = this.HostingEnvironment.WebRootPath + "\\Music\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }

        private string GetPathAndFilenameImagens(string filename, string pasta, int Id)
        {
            string path = this.HostingEnvironment.WebRootPath + "\\ImagensGaleria\\" + Id + "Pagina" + pasta + "\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }

        private string EnsureCorrectFilename(string filename, int Id)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return Id + "-" + filename;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<string> SalvarVideo(IFormFile files, string Nome, int Id, int PaginaEscolhida,
            [FromServices] IHostingEnvironment hostingEnvironment)
        {
            string filename = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.ToString().Trim('"');

            var video = new Video()
            {
                ArquivoVideo = "",
                Nome = Nome,
                Pagina_ = Id,
                PaginaEscolhida = PaginaEscolhida
            };

            try
            {
                await db.Video.AddAsync(video);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "";
            }

            filename = this.EnsureCorrectFilename(filename, video.Id);

            video.ArquivoVideo = "/VideosGaleria/" + filename;
            db.Entry(video).State = EntityState.Modified;
            await db.SaveChangesAsync();

            byte[] buffer = new byte[16 * 1024];

            using (FileStream output = System.IO.File.Create(this.GetPathAndFilenameArquivoVideo(filename)))
            {
                using (Stream input = files.OpenReadStream())
                {
                    long totalReadBytes = 0;
                    int readBytes;

                    while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        await output.WriteAsync(buffer, 0, readBytes);
                        totalReadBytes += readBytes;
                        await Task.Delay(10); // It is only to make the process slower
                    }
                }
            }

            return $"Chave do elemento: {video.Id}";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<IActionResult> SalvarMusica(IFormFile files, int Id,
            [FromServices] IHostingEnvironment hostingEnvironment)
        {

            string filename = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.ToString().Trim('"');

            var pag = db.Pagina.Find(Id);

            filename = this.EnsureCorrectFilename(filename, pag.Id);

            pag.ArquivoMusic = "/Music/" + filename;
            db.Entry(pag).State = EntityState.Modified;
            await db.SaveChangesAsync();

            byte[] buffer = new byte[16 * 1024];

            using (FileStream output = System.IO.File.Create(this.GetPathAndFilenameArquivoMusica(filename, Id)))
            {
                using (Stream input = files.OpenReadStream())
                {
                    long totalReadBytes = 0;
                    int readBytes;

                    while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, readBytes);
                        totalReadBytes += readBytes;
                        // await Task.Delay(10); // It is only to make the process slower
                    }
                }
            }

            return this.Content("success");
        }


        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<IActionResult> ImageUpload(IList<IFormFile> files, int Id, string pasta, int PaginaEscolhida,
            [FromServices] IHostingEnvironment hostingEnvironment)
        {
            var local = await db.PastaImagem
                .Include(p => p.Imagens)
                .FirstAsync(p => p.Id == int.Parse(pasta));
            var location = local.Nome;

            long totalBytes = files.Sum(f => f.Length);
            foreach (IFormFile source in files)
            {
                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');

                Imagem img = new Imagem
                {
                    ArquivoImagem = "",
                    Pagina_ = Id,
                    Nome = "Imagem",
                    Width = 100,
                    PaginaEscolhida = PaginaEscolhida
                };

                await db.Imagem.AddAsync(img);
                local.Imagens.Add(img);
                await db.SaveChangesAsync();

                filename = this.EnsureCorrectFilename(filename, img.Id);

                img.ArquivoImagem = "/ImagensGaleria/" + Id + "Pagina" + location + "/" + filename;
                db.Entry(img).State = EntityState.Modified;
                await db.SaveChangesAsync();                

                byte[] buffer = new byte[16 * 1024];

                using (FileStream output = System.IO.File.Create(this.GetPathAndFilenameImagens(filename, location, Id)))
                {
                    using (Stream input = source.OpenReadStream())
                    {
                        long totalReadBytes = 0;
                        int readBytes;

                        while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            totalReadBytes += readBytes;
                            // await Task.Delay(10); // It is only to make the process slower
                        }
                    }
                }
            }

            return this.Content("success");
        }


    }
}