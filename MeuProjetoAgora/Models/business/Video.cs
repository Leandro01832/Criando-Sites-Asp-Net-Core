
using Newtonsoft.Json;
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
   public class Video
    {
        [Key]
        public int IdVideo { get; set; }       

        public string ArquivoVideo { get; set; } 

        [Range(1, 10000, ErrorMessage = "Escolha em qual bloco vai estar o video.")]
        [Display(Name = "Colocar em qual bloco o Video?")]
        public int div_ { get; set; }
        [ForeignKey("div_")]
        [JsonIgnore]
        public virtual Div div { get; set; }
        
    }
}
