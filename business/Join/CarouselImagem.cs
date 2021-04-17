
using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Join
{
    public class CarouselImagem
    {
        public int CarouselId { get; set; }
        public int ImagemId { get; set; }
        public Carousel Carousel { get; set; }
        public Imagem Imagem { get; set; }
    }
}
