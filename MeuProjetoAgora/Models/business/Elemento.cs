


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
   public class Elemento
    {
        [Key]
        public int IdElemento { get; set; }

        public string Nome { get; set; }

        public int? texto_ { get; set; }
        [ForeignKey("texto_")]
        [JsonIgnore]
        public virtual Texto texto { get; set; }

        public int? carousel_ { get; set; }
        [ForeignKey("carousel_")]
        [JsonIgnore]
        public virtual Carousel carousel { get; set; }

        public int? imagem_ { get; set; }
        [ForeignKey("imagem_")]
        [JsonIgnore]
        public virtual Imagem imagem { get; set; }

        [Display(Name = "Video")]
        public int? video_ { get; set; }
        [ForeignKey("video_")]
        [JsonIgnore]
        public virtual Video video { get; set; }

        [Display(Name = "Link")]
        public int? link_ { get; set; }
        [ForeignKey("link_")]
        [JsonIgnore]
        public virtual Link link { get; set; }

        [Display(Name = "Formulario")]
        public int? form_ { get; set; }
        [ForeignKey("form_")]
        [JsonIgnore]
        public virtual Formulario form { get; set; }

        [Display(Name = "Tabela")]
        public int? table_ { get; set; }
        [ForeignKey("table_")]
        [JsonIgnore]
        public virtual Table table { get; set; }

        [Range(1, 10000, ErrorMessage = "Escolha em qual bloco vai estar o elemento?")]
        [Display(Name ="Bloco")]
        public int? div_2 { get; set; }
        [ForeignKey("div_2")]
        [JsonIgnore]
        public virtual Div div { get; set; }

        public int Ordem { get; set; }

        public bool Renderizar { get; set; }
    }
}
