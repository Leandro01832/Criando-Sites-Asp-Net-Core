using MeuProjetoAgora.Join;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.business.Elementos
{
    public class ElementoDependente
    {
        [Key]
        public int IdElementoDependente { get; set; }        
        public virtual List<ElementoDependenteElemento> Elemento { get; set; }
        public int? Elemento_ { get; set; }
        [ForeignKey("Elemento_")]
        public virtual Elemento Dependente { get; set; }

    }
}
