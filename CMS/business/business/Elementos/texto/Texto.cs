using business.business.element;
using business.business.Elementos.element;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace business.business.Elementos.texto
{
    public class Texto : Elemento
    {
        [Display(Name = "Texto")]
        public string PalavrasTexto { get; set; }
        public virtual List<Elemento> Elemento { get; set; }
    }
}
