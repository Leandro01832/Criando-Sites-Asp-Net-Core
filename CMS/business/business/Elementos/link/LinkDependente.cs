using business.business.element;
using business.business.Elementos.element;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace business.business.Elementos.link
{
    public abstract class LinkDependente : Elemento
    {

        [Display(Name = "Qual é a pagina de destino?")]
        public int? PaginaId { get; set; }
        [JsonIgnore]
        public virtual Pagina Pagina { get; set; }
    }
}
