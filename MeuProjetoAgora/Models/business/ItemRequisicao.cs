using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.Models.business
{
    public class ItemRequisicao
    {
        [Key]
        public int IdItem { get; set; }
        public int Quantidade { get; set; }
        public int requisicao_ { get; set; }
        [JsonIgnore]
        [ForeignKey("requisicao_")]
        public virtual Requisicao Requisicao { get; set; }
        public int produto_ { get; set; }
        [JsonIgnore]
        [ForeignKey("produto_")]
        public virtual Produto produto { get; set; }
    }
}