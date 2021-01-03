using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.business.Elemento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Join
{
    public class PaginaCarouselPagina
    {
        public int CarouselPaginaId { get; set; }
        public int PaginaId { get; set; }
        public CarouselPagina CarouselPagina { get; set; }
        public Pagina Pagina { get; set; }
    }
}
