using business.business.element;
using business.ecommerce;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace business.business.Elementos.produto
{
    public abstract class ProdutoDependente : ElementoDependente
    {
        [Display(Name = "Tabela do produto")]
        public int? TableId { get; set; }
        public Table Table { get; set; }
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