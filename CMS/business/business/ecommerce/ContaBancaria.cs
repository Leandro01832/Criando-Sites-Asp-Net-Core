using business.business;
using System.ComponentModel.DataAnnotations;

namespace business.ecommerce
{
    public class ContaBancaria : BaseModel
    {
        [Display(Name = "Código do banco")]
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public string CodigoBanco { get; set; }
        [Display(Name ="Tipo da conta")]
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public string TipoConta { get; set; }
        public string Agencia { get; set; }
        public string DVAgencia { get; set; }
        public string Conta { get; set; }
        public string DVConta { get; set; }
        [Required]
        public virtual string ClienteId { get; set; }


    }
}