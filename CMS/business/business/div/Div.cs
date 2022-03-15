using business.Back;
using business.business;
using business.business.Elementos.element;
using business.contrato;
using business.implementacao;
using business.Join;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.div
{
    public abstract class Div : BaseModel, IMudancaEstado
    {
        private string nome = "bloco";
        private string elementos = "";
        private string colunas = "auto";
        private string divisao = "col-md-12";
        private int padding = 5;
        private int height = 200;
        private int ordem = 0;
        private int desenhado = 0;
        private int borderRadius = 0;
        private MudancaEstado mudanca;

        public Div()
        {
            mudanca = new MudancaEstado();
            Elemento = new List<DivElemento>();
        }

        [Required(ErrorMessage = "O nome do bloco é necessário")]
        [Display(Name ="Nome do bloco")]
        public string Nome { get { return nome; } set { nome = value; } }

        [Display(Name = "Conteudo centralizado")]
        public int Padding { get { return padding; } set { padding = value; } }

        [Display(Name = "Altura")]
        public int Height { get { return height; } set { height = value; } }

        [Display(Name = "Quantidade de colunas")]
        public string Colunas { get { return colunas; } set { colunas = value; } }

        public int Desenhado { get { return desenhado; } set { desenhado = value; } }

        [Display(Name = "Espaçamento")]
        public string Divisao { get { return divisao; } set { divisao = value; } }

        [Display(Name = "Borda arredondada")]
        public int BorderRadius { get { return borderRadius; } set { borderRadius = value; } }          

        public int Ordem { get { return ordem; } set { ordem = value; } }
        
        [JsonIgnore]
        public virtual Background Background { get; set; }
        [JsonIgnore]
        public virtual List<DivElemento> Elemento { get; set; }
        [JsonIgnore]
        public virtual List<DivPagina> Pagina { get; set; }

        public int Pagina_ { get; set; }

        [NotMapped]
        public string Elementos { get { return elementos; } set { elementos = value; } }

        public void IncluiElemento(Elemento elemento)
        {
            this.Elemento.Add(new DivElemento { Elemento = elemento });
        }

        public BaseModel MudarEstado(BaseModel VelhoEstado, BaseModel m)
        {
            return mudanca.MudarEstado(VelhoEstado, m);
        }
    }
}
