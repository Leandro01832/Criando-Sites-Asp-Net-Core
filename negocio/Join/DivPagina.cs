using MeuProjetoAgora.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Join
{
    public class DivPagina
    {
        public int PaginaId { get; set; }
        public int DivId { get; set; }
        public Div Div { get; set; }
        public Pagina Pagina { get; set; }
    }
}
