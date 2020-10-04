using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.Models.business
{
    public class InfoEntrega
    {
        [Key]
        public int IdInfoEntrega { get; set; }
        [Display(Name ="Deseja fazer entrega por todo o brasil utilizando os serviços do correios")]
        public bool entregaCorreio { get; set; }

        [Display(Name = "Largura da caixa em centimetros")]
        public int? LarguraCaixa { get; set; }

        [Display(Name = "Altura da caixa em centimetros")]
        public int? AlturaCaixa { get; set; }

        [Display(Name ="Peso da caixa em Kilo Gramas")]
        public int? PesoCaixa { get; set; }

        [Display(Name = "Comprimento da caixa em centimetros")]
        public int? ComprimentoCaixa { get; set; }

        [Display(Name = "Cidades de entrega de produto")]
        public string CidadesEntrega { get; set; }
        [Display(Name = "Estados de entrega de produto")]
        public string EstadosEntrega { get; set; }
        [Display(Name = "Informe o valor do frete")]
        public decimal? ValorFrete { get; set; }
        [Required]
        public virtual string ClienteId { get; set; }
    }
}