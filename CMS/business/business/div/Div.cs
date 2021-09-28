using business.Back;
using business.business;
using business.business.Elementos.element;
using business.Join;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.div
{
    public abstract class Div : BaseModel
    {

        [Required(ErrorMessage = "O nome do bloco é necessário")]
        [Display(Name ="Nome do bloco")]
        public string Nome { get; set; }

        [Display(Name = "Conteudo centralizado")]
        public int Padding { get; set; }

        [Display(Name = "Altura")]
        public int Height { get; set; }

        [Display(Name = "Quantidade de colunas")]
        public string Colunas { get; set; }

        public int Desenhado { get; set; }

        [Display(Name = "Espaçamento")]
        public string Divisao { get; set; }

        [Display(Name = "Borda arredondada")]
        public int BorderRadius { get; set; }          

        public int Ordem { get; set; }
        
        [Display(Name = "Qual plano de fundo do bloco?")]
        public int BackgroundId { get; set; }
        [JsonIgnore]
        public virtual Background Background { get; set; }
        [JsonIgnore]
        public virtual List<DivElemento> Elemento { get; set; }
        [JsonIgnore]
        public virtual List<DivPagina> Pagina { get; set; }

        public int Pagina_ { get; set; }

        [NotMapped]
        public string Elementos { get; set; }

        public void IncluiElemento(Elemento elemento)
        {
            this.Elemento.Add(new DivElemento { Elemento = elemento });
        }


    }
}
