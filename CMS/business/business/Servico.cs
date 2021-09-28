using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.business
{
    public class Servico
    {
        [Key, ForeignKey("Pedido")]
        public int IdServico { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }
        
        
    }
}
