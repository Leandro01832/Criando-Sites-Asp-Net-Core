using MeuProjetoAgora.business.Elementos;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MeuProjetoAgora.business
{
    public class ItemRequisicao
    {

        [Key]
        public int IdItem { get; set; }
        public int Quantidade { get; set; }
        public int requisicao_ { get; set; }
        [Required]

        public decimal PrecoUnitario { get; private set; }
        [JsonIgnore]
        [ForeignKey("requisicao_")]
        public virtual Requisicao Requisicao { get; set; }
        public int produto_ { get; set; }
        [JsonIgnore]
        [ForeignKey("produto_")]
        public virtual Produto produto { get; set; }

        internal void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }
    }
}