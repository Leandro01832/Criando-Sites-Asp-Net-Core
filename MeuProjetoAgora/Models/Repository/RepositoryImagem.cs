
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
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryImagem
    {
        Task SaveImagemsAsync(List<Imagem> imagens);
        Task<string> SaveImagem(ViewModelElemento elemento, IList<IFormFile> files);
        Task EditarImagem(ViewModelElemento elemento);
        Task apagarImagem(ViewModelElemento elemento);
        string EnsureCorrectFilename(string filename, int Id);
        string GetPathAndFilenameImagens(string filename, string pasta, int? Id);
    }



    public class RepositoryImagem : BaseRepository<Imagem>, IRepositoryImagem
    {
        public IHostingEnvironment HostingEnvironment { get; }

        public RepositoryImagem(IConfiguration configuration,
            ApplicationDbContext contexto, IHostingEnvironment hostingEnvironment) : base(configuration, contexto)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public async Task SaveImagemsAsync(List<Imagem> imagens)
        {
            await dbSet.AddRangeAsync(imagens);
            await contexto.SaveChangesAsync();
        }

        public string GetPathAndFilenameImagens(string filename, string pasta, int? Id)
        {
            string path = this.HostingEnvironment.WebRootPath + "\\ImagensGaleria\\" + Id + "Pagina" + pasta + "\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }

        public string EnsureCorrectFilename(string filename, int Id)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return Id + "-" + filename;
        }        

        public async Task<string> SaveImagem(ViewModelElemento elemento, IList<IFormFile> files)
        {
            var local = await contexto.PastaImagem
                .Include(p => p.Imagens)
                .FirstAsync(p => p.IdPastaImagem == elemento.PastaImagemId);
            var location = local.Nome;
            var Iddiv = elemento.div;
            var Div = await contexto.Div.FirstAsync(d => d.IdDiv == Iddiv);

            long totalBytes = files.Sum(f => f.Length);
            foreach (IFormFile source in files)
            {
                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');

                

                Imagem img = new Imagem
                {
                    Arquivo = ""  
                };

                await dbSet.AddAsync(img);
                local.Imagens.Add(img);
                await contexto.SaveChangesAsync();

                filename = this.EnsureCorrectFilename(filename, img.IdImagem);

                img.Arquivo = "/ImagensGaleria/" + Div.PaginaId + "Pagina" + location + "/" + filename;
                contexto.Entry(img).State = EntityState.Modified;
                await contexto.SaveChangesAsync();

                var element = new Elemento();
                element.imagem_ = img.IdImagem;
                await contexto.Elemento.AddAsync(element);
                  await contexto.SaveChangesAsync();

                byte[] buffer = new byte[16 * 1024];

                using (FileStream output = System.IO.File.Create(this.GetPathAndFilenameImagens(filename, location, Div.PaginaId)))
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

            return "";
        }

        public Task EditarImagem(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task apagarImagem(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }
    }
}
