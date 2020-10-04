using MeuProjetoAgora.Models.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Join
{
    public class DivImagem
    {
        public int ImagemId { get; set; }
        public int DivId { get; set; }
        public Div Div { get; set; }
        public Imagem Imagem { get; set; }
    }
}
