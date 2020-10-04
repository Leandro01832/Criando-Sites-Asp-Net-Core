


using MeuProjetoAgora.Models.Join;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Web;

namespace MeuProjetoAgora.Models.business
{
    


    public class Imagem 
    {

        [Key]
        public int IdImagem { get; set; }

        [Display(Name = "Arquivo")]
        public string Arquivo { get; set; }        
        
        [JsonIgnore]
        public virtual List<Background> Backgrounds { get; set; }
        [JsonIgnore]
        public virtual List<CarouselImagem> Carousels { get; set; }
        [JsonIgnore]
        public virtual List<DivImagem> Divs { get; set; }

        [JsonIgnore]
        public virtual List<ProdutoImagem> Produto { get; set; }

        public int? PastaImagemId { get; set; }
        [JsonIgnore]
        public virtual PastaImagem PastaImagem { get; set; }

        
    }
}
