using business.business.element;
using business.business.Elementos.texto;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace business.business.Elementos.link
{
    public abstract class LinkDependente : ElementoDependente
    {
        [Display(Name = "Qual é o texto do Link?")]
        public int? TextoId { get; set; }
        public Texto Texto { get; set; }

        [Display(Name = "Qual é a pagina de destino?")]
        public int? PaginaId { get; set; }
        [JsonIgnore]
        public virtual Pagina Pagina { get; set; }
    }
}
