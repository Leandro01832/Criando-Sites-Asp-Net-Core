using business.business.Elementos;
using business.business.Elementos.imagem;
using System.Collections.Generic;

namespace business.business
{
    public class PastaImagem : BaseModel
    {
        public string Nome { get; set; }
        public int PaginaId { get; set; }
        public Pagina Pagina { get; set; }
        public List<Imagem> Imagens { get; set; }
    }
}