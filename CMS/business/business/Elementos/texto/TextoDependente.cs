using business.business.element;
using business.business.Elementos.element;
using System.ComponentModel.DataAnnotations;

namespace business.business.Elementos.texto
{
    public class TextoDependente : Elemento
    {
        [Display(Name = "Texto")]
        public string PalavrasTexto { get; set; }
    }
}
