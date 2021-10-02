using business.business;
using business.business.carousel;

namespace business.Join
{
    public class PaginaCarouselPagina
    {
        public int? CarouselPaginaId { get; set; }
        public int? PaginaId { get; set; }
        public CarouselPagina CarouselPagina { get; set; }
        public Pagina Pagina { get; set; }
    }
}
