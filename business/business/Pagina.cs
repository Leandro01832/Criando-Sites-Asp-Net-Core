
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Join;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web;

namespace MeuProjetoAgora.business
{
    public class Pagina
    {
        [Key]
        public int IdPagina { get; set; }

        [Required(ErrorMessage = "O titulo é necessário")]
        [Display(Name = "Titulo da pagina")]
        public string Titulo { get; set; }

        [DataType(DataType.Url)]
        public string Facebook { get; set; }

        [DataType(DataType.Url)]
        public string Twiter { get; set; }

        [DataType(DataType.Url)]
        public string Instagram { get; set; }

        [Display(Name = "Arquivo")]
        public string ArquivoMusic { get; set; }

        [NotMapped]
        public string Html { get; set; }

        [Display(Name ="Informe todas as rotas de uma pagina separando por virgulas.")]
        public string Rotas { get; set; }

        public bool Music { get; set; }

        [Display(Name ="Manter a margem Direita e esquerda")]
        public bool Margem { get; set; }

        public bool Topo { get; set; }

        public bool Menu { get; set; }

        public bool Exibicao { get; set; }

        [JsonIgnore]
        public virtual List<Background> Background { get; set; }
        [JsonIgnore]
        public virtual List<PastaImagem> Pastas { get; set; }
        [JsonIgnore]
        public virtual List<DivPagina> Div { get; set; }
        [JsonIgnore]
        public virtual List<PaginaCarouselPagina> CarouselPagina { get; set; }


        [Range(1, 10000, ErrorMessage = "Escolha qual o site para esta pagina")]
        [Display(Name = "Qual é o site desta pagina?")]
        public int pedido_ { get; set; }
        [ForeignKey("pedido_")]
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }

        [NotMapped]
        public string Blocos { get; set; }

        public void IncluiDiv(Div div)
        {
            this.Div.Add(new DivPagina { Div = div });
        }
    }
}
