
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Web;

namespace MeuProjetoAgora.Models.business.Elemento
{
    


    public class Imagem : Elemento
    {
        [Display(Name = "Arquivo")]
        public string ArquivoImagem { get; set; }

        public int Width { get; set; }

        [JsonIgnore]
        public virtual List<Background> Backgrounds { get; set; }

        public int? PastaImagemId { get; set; }
        [JsonIgnore]
        public virtual PastaImagem PastaImagem { get; set; }

        
    }
}
