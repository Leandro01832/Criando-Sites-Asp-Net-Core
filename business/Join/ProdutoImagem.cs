using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Join
{
    public class ProdutoImagem
    {
        public int ProdutoId { get; set; }
        public int ImagemId { get; set; }
        public Produto Produto { get; set; }
        public Imagem Imagem { get; set; }
    }
}
