using business.business.element;
using business.business.Elementos.element;
using business.business.Elementos.texto;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace business.business.link
{
    public abstract class Link : ElementoComum
    {
        public int TextoId { get; set; }
        public Texto Texto { get; set; }

        [Display(Name = "Qual é a pagina de destino?")]
        public int? PaginaId { get; set; }
        [JsonIgnore]
        public virtual Pagina Pagina { get; set; }
    }
}
