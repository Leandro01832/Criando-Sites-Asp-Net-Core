using business.business.element;
using business.business.Elementos.element;

namespace business.business.Elementos
{
    public class Campo : ElementoComum
    {
        public int? FormularioId { get; set; }
        public Formulario Formulario { get; set; }

        public string Placeholder { get; set; }
        public string TipoCampo { get; set; }
    }
}