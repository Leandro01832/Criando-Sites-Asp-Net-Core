using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.Models.business
{
    public class ContaBancaria
    {
        [Key]
        public int IdContaBancaria { get; set; }
        [Display(Name = "Código do banco")]
        public string CodigoBanco { get; set; }
        [Display(Name ="Tipo da conta")]
        public string TipoConta { get; set; }
        public string Agencia { get; set; }
        public string DVAgencia { get; set; }
        public string Conta { get; set; }
        public string DVConta { get; set; }
        [Required]
        public virtual string ClienteId { get; set; }


    }
}