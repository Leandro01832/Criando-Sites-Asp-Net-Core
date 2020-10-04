using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public class RepositoryElemento : BaseRepository<Elemento>, IRepositoryElemento
    {
        public RepositoryElemento(IConfiguration configuration, ApplicationDbContext contexto,
            IRepositoryVideo repositoryVideo, IRepositoryLink repositoryLink, IRepositoryForm repositoryForm,
            IRepositoryTexto repositoryTexto, IRepositoryImagem repositoryImagem,
            IRepositoryCarousel repositoryCarousel, IRepositoryTable repositoryTable)
            : base(configuration, contexto)
        {
            RepositoryVideo = repositoryVideo;
            RepositoryLink = repositoryLink;
            RepositoryForm = repositoryForm;
            RepositoryTexto = repositoryTexto;
            RepositoryImagem = repositoryImagem;
            RepositoryCarousel = repositoryCarousel;
            RepositoryTable = repositoryTable;
        }

        public IRepositoryVideo RepositoryVideo { get; }
        public IRepositoryLink RepositoryLink { get; }
        public IRepositoryForm RepositoryForm { get; }
        public IRepositoryTexto RepositoryTexto { get; }
        public IRepositoryImagem RepositoryImagem { get; }
        public IRepositoryCarousel RepositoryCarousel { get; }
        public IRepositoryTable RepositoryTable { get; }

        public async Task Apagar(ViewModelElemento elemento)
        {
            if (elemento.elemento == "video")
            {
                await RepositoryVideo.apagarVideo(elemento);
            }

            if (elemento.elemento == "form")
            {
                await RepositoryForm.apagarForm(elemento);
            }
            if (elemento.elemento == "link")
            {
                await RepositoryLink.apagarLink(elemento);
            }
            if (elemento.elemento == "texto")
            {
                await RepositoryTexto.apagarTexto(elemento);
            }
            if (elemento.elemento == "imagem")
            {
                await RepositoryImagem.apagarImagem(elemento);
            }
            if (elemento.elemento == "carousel")
            {
                await RepositoryCarousel.apagarCarousel(elemento);
            }
            if (elemento.elemento == "table")
            {
                await RepositoryTable.apagarTable(elemento);
            }
        }

        public async Task Editar(ViewModelElemento elemento)

        {
            if (elemento.elemento == "video")
            {
                await RepositoryVideo.editarVideo(elemento);
            }

            if (elemento.elemento == "form")
            {
                await RepositoryForm.editarForm(elemento);
            }
            if (elemento.elemento == "link")
            {
                await RepositoryLink.editarLink(elemento);
            }
            if (elemento.elemento == "texto")
            {
                await RepositoryTexto.editarTexto(elemento);
            }
            if (elemento.elemento == "imagem")
            {
                await RepositoryImagem.EditarImagem(elemento);
            }
            if (elemento.elemento == "carousel")
            {
                await RepositoryCarousel.editarCarousel(elemento);
            }
            if (elemento.elemento == "table")
            {
                await RepositoryTable.editarTable(elemento);
            }
        }

        public Task Ler(int? DivId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> salvar(ViewModelElemento elemento, IList<IFormFile> files)
        {
            if(elemento.elemento == "video")
            {
              await  RepositoryVideo.salvarVideo(elemento, files);
            }

            if (elemento.elemento == "form")
            {
                await RepositoryForm.salvarForm(elemento, files);
            }
            if (elemento.elemento == "link")
            {
                await RepositoryLink.salvarLink(elemento, files);
            }
            if (elemento.elemento == "texto")
            {
                await RepositoryTexto.salvarTexto(elemento, files);
            }
            if (elemento.elemento == "imagem")
            {
                await RepositoryImagem.SaveImagem(elemento, files);
            }
            if (elemento.elemento == "carousel")
            {
                await RepositoryCarousel.salvarCarousel(elemento, files);
            }
            if (elemento.elemento == "table")
            {
                await RepositoryTable.salvarTable(elemento, files);
            }

            return "";
        }
    }
}
