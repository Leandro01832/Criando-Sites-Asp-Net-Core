using business.Back;
using business.business;
using business.business.Elementos.imagem;
using business.div;
using business.Join;
using System;
using System.Collections.Generic;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Pedido pedido = new Pedido();

            Div bloco1 = new DivComum
            {
                Background = new BackgroundCor(),
                Colunas = "",
                BorderRadius = 10,
                Desenhado = 0,
                Divisao = "",
                Elemento = new List<DivElemento>(),
                Elementos = "",
                Height = 10,
                Nome = "bloco1",
                Ordem = 0,
                Padding = 5,
                Pagina_ = 1

            };

            Imagem img = new Imagem
            {
                Nome = "",
                Background = null,
                ArquivoImagem = "",
                div = new List<DivElemento>(),
                Ordem = 1,
                Pagina_ = 1,
                PastaImagemId = 1,
                PastaImagem = new PastaImagem(),
                Width = 100
            };

            List<DivElemento> elementos = new List<DivElemento>
            {
                 new DivElemento
                 {
                      Div = bloco1,
                       DivId = bloco1.Id,
                        Elemento = img,
                        ElementoId = img.Id
                 }
            };



            List<DivPagina> divs = new List<DivPagina>();
            divs.Add(new DivPagina
            {
                Div = bloco1,
                DivId = bloco1.Id
            });

            Pagina pagina = new Pagina
            {
                Html = "",
                Rotas = "",
                ArquivoMusic = "",
                Blocos = "",
                Titulo = "vida louca",
                Div = divs,
                CarouselPagina = new List<PaginaCarouselPagina>(),
                Margem = false,
                Menu = false,
                Topo = false,
                Exibicao = false,
                Music = false,
            };

            pedido.Paginas = new List<Pagina>();
            pedido.Paginas.Add(pagina);


            Console.Read();


        }
    }
}
