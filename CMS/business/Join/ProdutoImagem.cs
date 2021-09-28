using business.business.Elementos.element;
using business.business.Elementos.imagem;

namespace business.Join
{
    public class ProdutoImagem
    {
        public int ElementoId { get; set; }
        public int ImagemId { get; set; }
        public Elemento Elemento { get; set; }
        public Imagem Imagem { get; set; }
    }
}
