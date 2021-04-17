using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.business.Elementos
{
   public class Link : Elemento
    {
        public bool UrlLink { get; set; }
        public bool Menu { get; set; }
        public string TextoLink { get; set; }

        [Display(Name = "Qual é a pagina de destino?")]
        public int? paginaDestinoLink_ { get; set; }
        [ForeignKey("paginaDestinoLink_")]
        [JsonIgnore]
        public virtual Pagina Destino { get; set; }

        


    }
}
