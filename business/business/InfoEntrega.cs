﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.business
{
    public class InfoEntrega
    {
        [Key]
        public int IdInfoEntrega { get; set; }        

        [Display(Name = "Largura da caixa em centimetros")]
        public int? LarguraCaixa { get; set; }

        [Display(Name = "Altura da caixa em centimetros")]
        public int? AlturaCaixa { get; set; }

        [Display(Name ="Peso da caixa em Kilo Gramas")]
        public int? PesoCaixa { get; set; }

        [Display(Name = "Comprimento da caixa em centimetros")]
        public int? ComprimentoCaixa { get; set; }
        
        [Required]
        public virtual string ClienteId { get; set; }
    }
}