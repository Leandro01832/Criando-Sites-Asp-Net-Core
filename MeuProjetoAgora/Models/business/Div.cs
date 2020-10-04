


using MeuProjetoAgora.Models.Join;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MeuProjetoAgora.Models.business
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

        public int Ordem { get; set; }

        [Range(1, 10000, ErrorMessage ="Escolha um plano de fundo para a div")]
        [Display(Name = "Qual plano de fundo do bloco?")]
        public int background_ { get; set; }
        [ForeignKey("background_")]
        
        public virtual Background Background { get; set; }

        public virtual List<Formulario> form { get; set; }

        public virtual List<Table> Tabelas { get; set; }

        public virtual List<Texto> Textos { get; set; }
        
        public virtual List<Carousel> Carousel { get; set; }
        
        public virtual List<Video> Video { get; set; }
        
        public virtual List<DivImagem> Imagem { get; set; }

        public virtual List<Link> Link { get; set; }

        public virtual List<Elemento> Elemento { get; set; }
        
        [Display(Name = "colocar em qual pagina o bloco?")]
        public int? PaginaId { get; set; }       
        public virtual Pagina Pagina { get; set; }

        


    }
}
