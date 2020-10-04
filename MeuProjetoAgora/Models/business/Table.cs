using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.business
{
   public class Table
    {
        [Key]
        public int IdTable { get; set; }
        public string Nome { get; set; }
        public string Estilo { get; set; }
        [JsonIgnore]
        public virtual List<Produto> Produtos { get; set; }

        [Range(1, 10000, ErrorMessage = "Escolha em qual bloco vai estar o texto")]
        [Display(Name = "Colocar em qual bloco a tabela produtos?")]
        public int div_ { get; set; }
        [ForeignKey("div_")]
        [JsonIgnore]
        public virtual Div div { get; set; }
    }
}
