using MeuProjetoAgora.Models.business;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.Models.business
{
    public class InfoVenda
    {
        [Key]
        public int IdInfoVenda { get; set; } 
        public string Cpf { get; set; }
        [Required]
        public virtual string ClienteId { get; set; }
    }
}