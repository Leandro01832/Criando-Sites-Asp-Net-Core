using business.business;
using business.business.carousel;
using business.business.element;
using business.business.Elementos;
using business.business.Elementos.element;
using business.business.Elementos.imagem;
using business.business.Elementos.link;
using business.business.Elementos.produto;
using business.business.Elementos.texto;
using business.Join;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public class RepositoryElemento : BaseRepository<Elemento>, IRepositoryElemento
    {
        public IRepositoryImagem RepositoryImagem { get; }
        public IRepositoryPagina RepositoryPagina { get; }
        public IRepositoryCampo RepositoryCampo { get; }
        public IRepositoryForm RepositoryForm { get; }
        public IRepositoryTable RepositoryTable { get; }
        public IRepositoryProduto RepositoryProduto { get; }
        public IRepositoryTexto RepositoryTexto { get; }
        public IRepositoryElementoDependente RepositoryElementoDependente { get; }
        public IRepositoryCarouselPaginaCarousel RepositoryCarouselPaginaCarousel { get; }
        public IRepositoryLink RepositoryLink { get; }
        public IRepositoryCarousel RepositoryCarousel { get; }
        public IRepositoryDropdown RepositoryDropdown { get; }

        public RepositoryElemento(IConfiguration configuration, ApplicationDbContext contexto,
            IRepositoryImagem repositoryImagem, IRepositoryPagina repositoryPagina, IRepositoryCampo repositoryCampo,
            IRepositoryForm repositoryForm, IRepositoryTable repositoryTable, IRepositoryProduto repositoryProduto,
            IRepositoryTexto repositoryTexto, IRepositoryElementoDependente repositoryElementoDependente,
             IRepositoryCarouselPaginaCarousel repositoryCarouselPaginaCarousel, IRepositoryLink repositoryLink,
             IRepositoryCarousel repositoryCarousel, IRepositoryDropdown repositoryDropdown)
            : base(configuration, contexto)
        {
            RepositoryImagem = repositoryImagem;
            RepositoryPagina = repositoryPagina;
            RepositoryCampo = repositoryCampo;
            RepositoryForm = repositoryForm;
            RepositoryTable = repositoryTable;
            RepositoryProduto = repositoryProduto;
            RepositoryTexto = repositoryTexto;
            RepositoryElementoDependente = repositoryElementoDependente;
            RepositoryCarouselPaginaCarousel = repositoryCarouselPaginaCarousel;
            RepositoryLink = repositoryLink;
            RepositoryCarousel = repositoryCarousel;
            RepositoryDropdown = repositoryDropdown;
        }

        public async Task<string> Editar(Elemento elemento)
        {
            contexto.Entry(elemento).State = EntityState.Modified;
            await contexto.SaveChangesAsync();

            if (elemento is ElementoDependente)
            {
                var depe = (ElementoDependente)elemento;

                var arr = depe.ElementosDependentes.Replace(" ", "").Split(',');

                depe = dbSet.OfType<ElementoDependente>().Include(e => e.Dependentes).First(e => e.Id == elemento.Id);

                foreach (var item in arr)
                    if (depe.Dependentes.FirstOrDefault(d => d.ElementoId == elemento.Id &&
                     d.ElementoDependenteId == int.Parse(item)) == null)
                        depe.IncluiElemento(dbSet.First(e => e.Id == int.Parse(item)));

                await contexto.SaveChangesAsync();

                foreach (var item in depe.Dependentes)
                    if (!arr.Contains(item.ElementoDependenteId.ToString()))
                    {
                        contexto.ElementoDependenteElemento.Remove(item);
                        await contexto.SaveChangesAsync();
                    }
            }
            

            return "";
        }

        public async Task<string> salvar(Elemento elemento)
        {
            elemento.Id = 0;
            await dbSet.AddAsync(elemento);
            await contexto.SaveChangesAsync();

            if (elemento is ElementoDependente)
            {
                var depe = (ElementoDependente)elemento;
                depe.Dependentes = new List<ElementoDependenteElemento>();

                var arr = depe.ElementosDependentes.Replace(" ", "").Split(',');

                foreach (var item in arr)
                    depe.IncluiElemento(dbSet.First(e => e.Id == int.Parse(item)));

                await contexto.SaveChangesAsync();

            }

            return $"Chave do elemento {elemento.Id}";
        }
        

        private async Task salvarPaginaDependente(Elemento elemento, int v)
        {
            var pagina = await contexto.Pagina.FirstAsync(p => p.Id == v);
            var ele = await contexto.CarouselPagina.Include(e => e.Paginas)
            .FirstAsync(e => e.Id == elemento.Id);

            ele.IncluiPagina(pagina);
            await contexto.SaveChangesAsync();
        }

        private async Task salvarElementoDependente(Elemento elemento)
        {
            var elementoDependente = new ImagemDependente();
            await contexto.ElementoDependente.AddAsync(elementoDependente);
            await contexto.SaveChangesAsync();
            var ele = await contexto.ElementoDependente.Include(e => e.Dependentes)
            .FirstAsync(e => e.Id == elemento.Id);
            ele.IncluiElemento(elementoDependente);
            await contexto.SaveChangesAsync();
        }

        private async Task ApagarElementosDependentes(ElementoDependente elemento)
        {
            if (elemento.Dependentes != null)
            {
                foreach (var dependente in elemento.Dependentes)
                {
                    if (!elemento.ElementosDependentes.Contains(dependente.ElementoDependente.Id.ToString()))
                    {
                        ElementoDependenteElemento depe;
                        depe = await RepositoryElementoDependente.TestarElementoDependenteElemento(dependente);
                        if (depe != null)
                        {
                            contexto.ElementoDependenteElemento.Remove(depe);
                        }
                    }
                }
                await contexto.SaveChangesAsync();
            }
        }

        private async Task ApagarPaginasDependentes(string elementosDependentes, Elemento elemento)
        {
            var cp = (CarouselPagina)elemento;
            if (cp.Paginas != null)
            {
                foreach (var dependente in cp.Paginas)
                {
                    if (!elementosDependentes.Contains(dependente.Pagina.Id.ToString()))
                    {
                        PaginaCarouselPagina depe;
                        depe = await RepositoryCarouselPaginaCarousel.TestarCarouselPaginaCarousel(dependente);
                        if (depe != null)
                        {
                            contexto.PaginaCarouselPagina.Remove(depe);
                        }
                    }
                }
                await contexto.SaveChangesAsync();
            }
        }

        public IIncludableQueryable<Elemento, Elemento> includes()
        {
            var l = contexto.Elemento
                .Include(e => e.div)
                .ThenInclude(e => e.Div)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pedido)
                .Include(e => e.div)
                .ThenInclude(e => e.Elemento);
            return l;
        }
    }
}