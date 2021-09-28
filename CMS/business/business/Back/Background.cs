using business.business;
using business.div;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace business.Back
{
    public abstract class Background : BaseModel
    {
        [Required(ErrorMessage ="O nome do plano de fundo é necessário")]
        [Display(Name ="Nome do plano de fundo")]
        public string Nome { get; set; }
        
        [Display(Name = "Em qual pagina colocar o plano de fundo")]
        public int PaginaId { get; set; }        
        public virtual Pagina Pagina { get; set; }        

        public virtual List<Div> Div { get; set; }

    }
}
