using business.business.Elementos;
using business.business.Elementos.imagem;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.business
{
    public class PastaImagem : BaseModel
    {
        public string Nome { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public List<Imagem> Imagens { get; set; }

        [NotMapped]
        public string Identifica { get { return Nome + " chave - " + Id.ToString(); } }
    }
}