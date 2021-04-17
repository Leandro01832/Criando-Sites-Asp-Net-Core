
using MeuProjetoAgora.Join;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MeuProjetoAgora.business
{
   public class Div
    {
        [Key]
        public int IdDiv { get; set; }

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

        public bool Fixado { get; set; }
        public bool EscolherPosicao { get; set; }
        public int PosicaoFixacao { get; set; }
        public int InicioFixacao { get; set; }

        public int EixoYBlocoFixado { get; set; }

        public int EixoXBlocoFixado { get; set; }        

        public int Ordem { get; set; }
        
        [Display(Name = "Qual plano de fundo do bloco?")]
        public int background_ { get; set; }
        [ForeignKey("background_")]
        [JsonIgnore]
        public virtual Background Background { get; set; }
        [JsonIgnore]
        public virtual List<DivElemento> Elemento { get; set; }
        [JsonIgnore]
        public virtual List<DivPagina> Pagina { get; set; }

        public int Pagina_ { get; set; }

        [NotMapped]
        public string Elementos { get; set; }

        public void IncluiElemento(MeuProjetoAgora.business.Elementos.Elemento elemento)
        {
            this.Elemento.Add(new DivElemento { Elemento = elemento });
        }


    }
}
