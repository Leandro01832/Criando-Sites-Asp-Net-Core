using business.Back;
using business.business.element;
using business.business.Elementos.element;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace business.business.Elementos.imagem
{
    public class ImagemDependente : Elemento
    {
        [Display(Name = "Arquivo")]
        public string ArquivoImagem { get; set; }

        public int Width { get; set; }

        public int? PastaImagemId { get; set; }
        [JsonIgnore]
        public virtual PastaImagem PastaImagem { get; set; }
    }
}
