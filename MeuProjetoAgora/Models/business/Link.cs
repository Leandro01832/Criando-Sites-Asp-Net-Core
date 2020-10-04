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
   public class Link
    {
        [Key]
        public int IdLink { get; set; }

        [Display(Name ="Qual é o texto?")]
        public int? texto_ { get; set; }
        [ForeignKey("texto_")]
        [JsonIgnore]
        public virtual Texto texto { get; set; }

        [Display(Name = "Qual é a imagem?*")]
        public int? imagem_ { get; set; }
        [ForeignKey("imagem_")]
        [JsonIgnore]
        public virtual Imagem imagem { get; set; }

        [Display(Name = "Qual é o bloco?")]
        public int? div_ { get; set; }
        [ForeignKey("div_")]
        [JsonIgnore]
        public virtual Div div { get; set; }

        [Display(Name = "Qual é a pagina de destino?")]
        public int? pagina_ { get; set; }
        [ForeignKey("pagina_")]
        [JsonIgnore]
        public virtual Pagina Destino { get; set; }

        public bool Url { get; set; }

        public string TextoLink { get; set; }


    }
}
