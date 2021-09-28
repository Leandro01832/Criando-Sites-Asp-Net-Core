using business.business.Elementos.element;
using business.Join;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.business.element
{
    public abstract class ElementoDependente : Elemento
    {   
        public virtual List<ElementoDependenteElemento> Dependentes { get; set; }
        [NotMapped]
        public string ElementosDependentes { get; set; }


        public void IncluiElemento(ElementoDependente elemento)
        {
            this.Dependentes.Add(new ElementoDependenteElemento { ElementoDependente = elemento });
        }

    }
}
