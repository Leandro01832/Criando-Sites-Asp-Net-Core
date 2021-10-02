using business.business.carousel;
using business.business.Elementos;
using business.business.Elementos.imagem;

namespace business.Join
{
    public class CarouselImagem
    {
        public int? CarouselId { get; set; }
        public int? ImagemId { get; set; }
        public CarouselImg Carousel { get; set; }
        public Imagem Imagem { get; set; }
    }
}
