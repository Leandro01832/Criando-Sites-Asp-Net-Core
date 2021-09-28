using business.business;
using System.ComponentModel.DataAnnotations;

namespace business.ecommerce
{
    public class InfoVenda : BaseModel
    {
        [Required(ErrorMessage ="Preencha o campo obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public long Numero { get; set; }
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public string Cep { get; set; }
        [Required]
        public virtual string ClienteId { get; set; }
    }
}