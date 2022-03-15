namespace business.div
{
    public class DivFixo : Div
    {

        private int eixoYBlocoFixado = 50;
        private int eixoXBlocoFixado = 50;

        public bool EscolherPosicao { get; set; }
        public int PosicaoFixacao { get; set; }
        public int InicioFixacao { get; set; }

        public int EixoYBlocoFixado { get { return eixoYBlocoFixado; } set { eixoYBlocoFixado = value; } }

        public int EixoXBlocoFixado { get { return eixoXBlocoFixado; } set { eixoXBlocoFixado = value; } }
    }
}
