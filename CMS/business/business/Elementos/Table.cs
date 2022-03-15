using business.business.Elementos.element;
using System.Collections.Generic;

namespace business.business.Elementos
{
    public class Table : Elemento
    {
        public virtual List<Elemento> Elemento { get; set; }
        public string EstiloTabela { get; set; }
    }
}
