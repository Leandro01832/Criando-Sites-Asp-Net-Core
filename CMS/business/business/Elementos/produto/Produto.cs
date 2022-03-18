using business.business.Elementos.element;
using business.ecommerce;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace business.business.Elementos.produto
{
   public abstract class Produto : Elemento
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
