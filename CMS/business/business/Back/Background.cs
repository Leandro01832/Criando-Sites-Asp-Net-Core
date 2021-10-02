using business.business;
using business.div;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.Back
{
    public abstract class Background : BaseModel
    {
        [Key, ForeignKey("Div")]
        public new int Id { get; set; }

        [Required(ErrorMessage ="O nome do plano de fundo é necessário")]
        [Display(Name ="Nome do plano de fundo")]
        public string Nome { get; set; }

        public virtual Div Div { get; set; }



    }
}
