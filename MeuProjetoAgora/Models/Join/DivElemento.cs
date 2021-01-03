using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.business.Elemento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Join
{
    public class DivElemento
    {
        public int ElementoId { get; set; }
        public int DivId { get; set; }
        public Div Div { get; set; }
        public Elemento Elemento { get; set; }
    }
}
