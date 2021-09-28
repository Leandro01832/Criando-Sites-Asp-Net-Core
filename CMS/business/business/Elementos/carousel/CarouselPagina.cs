using business.Join;
using System.Collections.Generic;

namespace business.business.carousel
{
    public class CarouselPagina : Carousel
    {
        public virtual List<PaginaCarouselPagina> Paginas { get; set; }

        public void IncluiPagina(Pagina pagina)
        {
            this.Paginas.Add(new PaginaCarouselPagina { Pagina = pagina });
        }
    }
}
