using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuProjetoAgora.business
{
    public class EnderecoRequisicao
    {
        [Key, ForeignKey("Requisicao")]
        public int IdEnderecoRequisicao { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        [Display(Name ="Numero")]
        public long NumeroCasa { get; set; }


        public virtual Requisicao Requisicao { get; set; }
    }
}