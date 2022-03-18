using business.Back;
using business.div;
using business.Join;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.business
{
    public class Pagina : BaseModel
    {
        private bool margem = true;
        private string rotas = "";
        private int mostrarDados = 0;


        public int StoryId { get; set; }
        public virtual Story Story { get; set; }

        [Required(ErrorMessage = "O titulo é necessário")]
        [Display(Name = "Titulo da pagina")]
        public string Titulo { get; set; }        

        [Display(Name = "Arquivo")]
        public string ArquivoMusic { get; set; }

        [NotMapped]
        public string Html { get; set; }

        [Display(Name ="Informe todas as rotas de uma pagina separando por virgulas.")]
        public string Rotas { get { return rotas; } set { rotas = value; } }

        public bool Music { get; set; }

        [Display(Name ="Manter a margem Direita e esquerda")]
        public bool Margem { get { return margem; } set { margem = value; } }

        public bool Topo { get; set; }

        public bool Menu { get; set; }

        public bool Exibicao { get; set; }
        
        [JsonIgnore]
        public virtual List<DivPagina> Div { get; set; }
        [JsonIgnore]
        public virtual List<PaginaCarouselPagina> CarouselPagina { get; set; }


        [Range(1, 10000, ErrorMessage = "Escolha qual o site para esta pagina")]
        [Display(Name = "Qual é o site desta pagina?")]
        public int PedidoId { get; set; }
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }

        [NotMapped]
        public string Blocos { get; set; }

        [NotMapped]
        public int MostrarDados { get { return mostrarDados; } set { mostrarDados = value; } }

        [NotMapped]
        public string NomeComId { get { return Titulo + " chave - " + Id.ToString(); } }

        public bool Layout { get; set; }

        public void IncluiDiv(Div div)
        {
            this.Div.Add(new DivPagina { Div = div });
        }
    }
}
