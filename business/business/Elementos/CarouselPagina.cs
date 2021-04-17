using MeuProjetoAgora.Join;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.business.Elementos
{
    public class CarouselPagina : Elemento
    {
        public virtual List<PaginaCarouselPagina> Paginas { get; set; }

        public void IncluiPagina(Pagina pagina)
        {
            this.Paginas.Add(new PaginaCarouselPagina { Pagina = pagina });
        }
    }
}
