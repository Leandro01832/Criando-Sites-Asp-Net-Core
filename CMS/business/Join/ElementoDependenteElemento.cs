using business.business.element;

namespace business.business.Elementos.element
{
    public class ElementoDependenteElemento
    {
        public int? ElementoDependenteId { get; set; }
        public int? ElementoId { get; set; }
        public virtual Elemento Elemento { get; set; }
        public virtual ElementoDependente ElementoDependente { get; set; }
    }
}