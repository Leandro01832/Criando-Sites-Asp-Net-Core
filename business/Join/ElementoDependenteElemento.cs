using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Join
{
    public class ElementoDependenteElemento
    {
        public int ElementoId { get; set; }
        public int ElementoDependenteId { get; set; }
        public Elemento Elemento { get; set; }
        public ElementoDependente ElementoDependente { get; set; }
    }
}
