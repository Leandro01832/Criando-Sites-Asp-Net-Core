using business.business.element;
using business.business.Elementos.element;

namespace business.Join
{
    public class ElementoDependenteElemento
    {
        public int ElementoId { get; set; }
        public int ElementoDependenteId { get; set; }
        public Elemento Elemento { get; set; }
        public ElementoDependente ElementoDependente { get; set; }
    }
}
