using business.business.element;
using business.business.Elementos.element;
using System.ComponentModel.DataAnnotations;

namespace business.business.Elementos.texto
{
    public class Texto : ElementoComum
    {
        [Display(Name = "Texto")]
        public string PalavrasTexto { get; set; }
    }
}
