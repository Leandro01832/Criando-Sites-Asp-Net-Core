using business.business.element;
using business.business.Elementos.element;

namespace business.business.Elementos
{
    public class Campo : ElementoComum
    {
        public int TableId { get; set; }
        public Table Table { get; set; }

        public string Placeholder { get; set; }
        public string TipoCampo { get; set; }
    }
}