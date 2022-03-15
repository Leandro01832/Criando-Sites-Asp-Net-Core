using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace business.business
{
    public class Endereco : BaseModel
    {
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public long Numero { get; set; }
        public string Cep { get; set; }
        [Required]
        public string ClienteId { get; set; }
    }
}
