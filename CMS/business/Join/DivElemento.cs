using business.business.Elementos.element;
using business.div;

namespace business.Join
{
    public class DivElemento
    {
        public int? ElementoId { get; set; }
        public int? DivId { get; set; }
        public virtual Div Div { get; set; }
        public virtual Elemento Elemento { get; set; }
    }
}
