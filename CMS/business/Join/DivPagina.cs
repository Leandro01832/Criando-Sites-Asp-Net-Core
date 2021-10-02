using business.business;
using business.div;

namespace business.Join
{
    public class DivPagina
    {
        public int? PaginaId { get; set; }
        public int? DivId { get; set; }
        public Div Div { get; set; }
        public Pagina Pagina { get; set; }
    }
}
