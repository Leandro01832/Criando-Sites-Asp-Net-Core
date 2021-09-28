using business.business.element;
using business.business.Elementos.element;
using business.business.Elementos.imagem;
using business.Join;
using CMS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryImagem
    {
        Task SaveImagems(List<Imagem> imagens);
        Task<string> SaveImagem(Elemento elemento);
        Task EditarImagem(Elemento elemento);
        Task apagarImagem(Elemento elemento);
        string EnsureCorrectFilename(string filename, int Id);
        string GetPathAndFilenameImagens(string filename, string pasta, int? Id);
        Task<ElementoDependente> TestarImagem(string id);
        Elemento RetornaImagem(Elemento elemento);
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

        public Task<string> SaveImagem(Elemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task EditarImagem(Elemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task apagarImagem(Elemento elemento)
        {
            throw new NotImplementedException();
        }

        public async Task<ElementoDependente> TestarImagem(string id)
        {
            Elemento imagem;
            try
            {
                imagem = await contexto.ElementoComum.
               OfType<Imagem>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
                if(imagem != null)
                {
                    var img = new ImagemDependente
                    {
                        Dependentes = new List<ElementoDependenteElemento>(),
                        ElementosDependentes = "",
                        div = imagem.div,
                        Nome = imagem.Nome,
                        Ordem = imagem.Ordem,
                        Pagina_ = imagem.Pagina_,
                        tipo = imagem.tipo
                    };
                   await contexto.ImagemDependente.AddAsync(img);
                    await contexto.SaveChangesAsync();
                    return img;
                }
                imagem = await contexto.ElementoDependente.
               OfType<Imagem>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
            }
            catch (Exception)
            {
                imagem = null;
            }
            return (ElementoDependente)imagem;
        }

        public Elemento RetornaImagem(Elemento elemento)
        {
            Imagem img = (Imagem)elemento;
            var imagem = new Imagem
            {
                Pagina_ = elemento.Pagina_,
                Id = elemento.Id,
                Nome = elemento.Nome,
                Width = img.Width,
                Ordem = elemento.Ordem,
                ArquivoImagem = img.ArquivoImagem,
                PastaImagemId = img.PastaImagemId

            };
            return imagem;
        }
    }
}