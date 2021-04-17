
using MeuProjetoAgora.business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.business
{
   public class Telefone
    {
        [Key]
        public int IdTelefone { get; set; }
        [Required(ErrorMessage = "DDD é obrigatório")]
        public string DDD_Celular { get; set; }
        [Required(ErrorMessage = "Celular é obrigatório")]
        public string Celular { get; set; }
        public string DDD_Telefone { get; set; }
        public string Fone { get; set; }
        [Required]
        public virtual string ClienteId { get; set; }
    }
}
