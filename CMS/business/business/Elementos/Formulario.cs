using business.business.Elementos.element;
using System.Collections.Generic;

namespace business.business.Elementos
{
    public class Formulario : Elemento
    {
        public virtual List<Elemento> Elemento { get; set; }
    }
}
