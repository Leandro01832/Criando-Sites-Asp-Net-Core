﻿
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.Models.business
{
    public class Requisicao
    {
        [Key]
        public int IdRequisicao { get; set; }
        public string Status { get; set; }
        [Display(Name = "Data do pedido")]
        public DateTime DataPedidoCompra { get; set; }
        [Display(Name = "Valor do pedido")]
        public string ValorPedido { get; set; }
        [NotMapped]
        public string Erro { get; set; }
        [JsonIgnore]
        public virtual List<ItemRequisicao> ItemRequisicao { get; set; }        
        public virtual EnderecoRequisicao Endereco { get; set; }
        [Required]
        public virtual string ClienteId { get; set; }
    }
}