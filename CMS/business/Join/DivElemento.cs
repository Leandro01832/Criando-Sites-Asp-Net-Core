﻿using business.business.Elementos.element;
using business.div;

namespace business.Join
{
    public class DivElemento
    {
        public int ElementoId { get; set; }
        public int DivId { get; set; }
        public Div Div { get; set; }
        public Elemento Elemento { get; set; }
    }
}