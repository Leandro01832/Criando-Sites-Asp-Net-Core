
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.Models.business.Elemento
{
    public class Produto : Elemento
    {
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public long? estoque { get; set; }
        [Required]
        public string Codigo { get; set; }
        public string Segmento { get; set; }
        [JsonIgnore]
        public virtual List<ItemRequisicao> Itens { get; set; }

        
    }
}