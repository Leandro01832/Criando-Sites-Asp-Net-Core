using MeuProjetoAgora.business;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.business
{
    public class InfoVenda
    {
        [Key]
        public int IdInfoVenda { get; set; } 
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