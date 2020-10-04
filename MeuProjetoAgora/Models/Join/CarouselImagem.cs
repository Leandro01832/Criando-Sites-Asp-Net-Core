
using MeuProjetoAgora.Models.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Join
{
    public class CarouselImagem
    {
        public int CarouselId { get; set; }
        public int ImagemId { get; set; }
        public Carousel Carousel { get; set; }
        public Imagem Imagem { get; set; }
    }
}
