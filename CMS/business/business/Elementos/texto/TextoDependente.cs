using business.business.element;
using System.ComponentModel.DataAnnotations;

namespace business.business.Elementos.texto
{
    public class TextoDependente : ElementoDependente
    {
        [Display(Name = "Texto")]
        public string PalavrasTexto { get; set; }
    }
}
