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
                var ele = await contexto.ElementoDependente.Include(e => e.Dependentes)
                   .ThenInclude(e => e.ElementoDependente)
                   .Include(e => e.Dependentes)
                   .ThenInclude(e => e.Elemento)
                   .FirstAsync(e => e.Id == elemento.Id);
                depe.Dependentes = ele.Dependentes;

                if (elemento.GetType().Name == "CarouselPagina")
                {
                    elemento = await contexto.CarouselPagina
                        .Include(e => e.Paginas)
                        .Include(e => e.Dependentes)
                        .ThenInclude(e => e.ElementoDependente)
                        .Include(e => e.Dependentes)
                        .ThenInclude(e => e.Elemento)
                        .FirstAsync(e => e.Id == elemento.Id);
                    depe.Dependentes = ele.Dependentes;
                } 
            }

            await elementosDependentes((ElementoDependente)elemento);

            return "";
        }

        public async Task<string> salvar(Elemento elemento)
        {
            elemento.Id = 0;
            await dbSet.AddAsync(elemento);
            await contexto.SaveChangesAsync();


            await elementosDependentes((ElementoDependente)elemento);

            return $"Chave do elemento {elemento.Id}";
        }

        private async Task elementosDependentes(ElementoDependente elemento)
        {
            var pagina1 = await contexto.Pagina.FirstAsync(e => e.Id == elemento.Pagina_);
            var site1 = await contexto.Pedido.FirstOrDefaultAsync(e => e.Id == pagina1.PedidoId);
            var cliente = site1.ClienteId;

            var listaString = new List<string>();
            string elementosGravados = "";
            if (!string.IsNullOrEmpty(elemento.ElementosDependentes))
                listaString = elemento.ElementosDependentes.Replace(" ", "").Split(',').ToList();

            if (elemento.Dependentes != null)
            {
                foreach (var dependente in elemento.Dependentes)
                {
                    elementosGravados += dependente.ElementoDependente.Id + ", ";
                }
            }
            await ApagarElementosDependentes(elemento);

            foreach (var id in listaString)
            {
                LinkDependente    LinkDependente; 
                CarouselImg       CarouselImg    ; 
                Campo             Campo          ; 
                Dropdown          Dropdown       ; 
                Table             Table          ;
                TextoDependente   textoDependente; 
                ImagemDependente ImagemDependente;
                ProdutoDependente ProdutoDependente;


                bool MesmoCliente = false;
                Elemento elementoDepe;

                try
                {
                    elementoDepe = await contexto.Elemento.FirstOrDefaultAsync(d => d.Id == int.Parse(id));
                }
                catch (Exception)
                {
                    elementoDepe = null;
                }
                if (elementoDepe != null)
                {
                    var paginaElementoDepe = await contexto.Pagina.FirstOrDefaultAsync(p => p.Id == elementoDepe.Pagina_);
                    if (paginaElementoDepe != null && paginaElementoDepe.PedidoId == site1.Id)
                    {
                        var site = await contexto.Pedido.FirstOrDefaultAsync(p => p.Id == paginaElementoDepe.PedidoId);
                        if (site.ClienteId == cliente)
                        {
                            MesmoCliente = true;
                        }
                    }
                }

                if (elemento is Dropdown)
                {
                    LinkDependente = (LinkDependente) await RepositoryLink.TestarLink(id);

                    if (LinkDependente != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento);
                    }
                }

                if (elemento is Formulario)
                {
                    Campo = (Campo) await RepositoryCampo.TestarCampo(id);

                    if (Campo != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento);
                    }
                }
                
                if (elemento is Carousel)
                {
                    if (elemento is CarouselPagina)
                    {
                        Pagina pagina = await RepositoryPagina.TestarPagina(id);

                        if (pagina != null && MesmoCliente && !elementosGravados.Contains(id))
                        {
                            await salvarElementoDependente(elemento);
                        }
                    }
                    else
                    {
                        ImagemDependente = (ImagemDependente) await RepositoryImagem.TestarImagem(id);

                        if (ImagemDependente != null && MesmoCliente && !elementosGravados.Contains(id))
                        {
                            await salvarElementoDependente(elemento);
                        }
                    }

                }

                if (elemento is ImagemDependente)
                {
                    CarouselImg = (CarouselImg) await RepositoryCarousel.TestarCarousel(id);
                    ProdutoDependente = (ProdutoDependente)await RepositoryProduto.TestarProduto(id);

                    if (CarouselImg != null && MesmoCliente && !elementosGravados.Contains(id) ||
                        ProdutoDependente != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento);
                    }
                }

                if (elemento is ProdutoDependente)
                {
                    ImagemDependente = (ImagemDependente)await RepositoryImagem.TestarImagem(id);
                    Table = (Table)await RepositoryTable.TestarTable(id);

                    if (ImagemDependente != null && MesmoCliente && !elementosGravados.Contains(id) ||
                        Table != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento);
                    }
                }

                if (elemento is Table)
                {
                    ProdutoDependente = (ProdutoDependente)await RepositoryProduto.TestarProduto(id);                    

                    if (ProdutoDependente != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento);
                    }
                }
                
                if (elemento is LinkDependente)
                {
                    ImagemDependente imagemLink = new ImagemDependente();
                    imagemLink = (ImagemDependente) await RepositoryImagem.TestarImagem(listaString[1]);
                    textoDependente = (TextoDependente) await RepositoryTexto.TestarTexto(listaString[0]);
                    Dropdown = (Dropdown)await RepositoryDropdown.TestarDropdown(id);

                    if (textoDependente != null && MesmoCliente && !elementosGravados.Contains(id) ||
                        Dropdown != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento);
                    }

                    if (imagemLink != null && MesmoCliente && !elementosGravados.Contains(id) ||
                        Dropdown != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento);
                    }

                    break;
                }

            }
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