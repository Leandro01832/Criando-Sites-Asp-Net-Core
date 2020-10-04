
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.Join;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.business
{
   public class Carousel
    {
        [Key]
        public int IdCarousel { get; set; }

        [Required(ErrorMessage = "O nome do carrossel é necessário")]
        [Display(Name ="Nome do carrossel")]
        public string Nome { get; set; }

        [Range(1, 10000, ErrorMessage = "Escolha em qual bloco vai estar o carrossel")]
        [Display(Name = "Colocar em qual bloco?")]
        public int div_2 { get; set; }
        [ForeignKey("div_2")]

        [JsonIgnore]
        public virtual Div Div { get; set; }

        [JsonIgnore]
        public virtual List<CarouselImagem> imagens { get; set; }

        

        public void IncluiImagem(Imagem imagem)
        {
            this.imagens.Add(new CarouselImagem { Imagem = imagem });
        }

    }
}
