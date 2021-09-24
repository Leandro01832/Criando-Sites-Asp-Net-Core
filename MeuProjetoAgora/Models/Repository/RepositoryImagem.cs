
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Data;
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
        Task SaveImagems(List<Imagem> imagens);
        Task<string> SaveImagem(ViewModelElemento elemento);
        Task EditarImagem(ViewModelElemento elemento);
        Task apagarImagem(ViewModelElemento elemento);
        string EnsureCorrectFilename(string filename, int Id);
        string GetPathAndFilenameImagens(string filename, string pasta, int? Id);
        Task<Imagem> TestarImagem(string id);
        Elemento RetornaImagem(ViewModelElemento elemento);
    }



    public class RepositoryImagem : BaseRepository<Imagem>, IRepositoryImagem
    {
        public IHostingEnvironment HostingEnvironment { get; }

        public RepositoryImagem(IConfiguration configuration,
            ApplicationDbContext contexto, IHostingEnvironment hostingEnvironment) : base(configuration, contexto)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public async Task SaveImagems(List<Imagem> imagens)
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

        public Task<string> SaveImagem(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task EditarImagem(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task apagarImagem(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public async Task<Imagem> TestarImagem(string id)
        {
            Imagem imagem;
            try
            {
                imagem = await contexto.Elemento.
               OfType<Imagem>().FirstOrDefaultAsync(e => e.IdElemento == int.Parse(id));
            }
            catch (Exception)
            {
                imagem = null;
            }
            return imagem;
        }

        public Elemento RetornaImagem(ViewModelElemento elemento)
        {
            var imagem = new Imagem
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                ElementosDependentes = elemento.elementosDependentes,
                Width = elemento.Width,
                Ordem = elemento.Ordem,
                ArquivoImagem = elemento.ArquivoImagem,
                PastaImagemId = elemento.PastaImagemId

            };
            return imagem;
        }
    }
}