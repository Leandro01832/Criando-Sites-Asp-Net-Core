using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace business.business
{
    public class Pedido : BaseModel
    {

        private int diasLiberados = 500;

        public bool Venda { get; set; }

        [MaxLength(30, ErrorMessage = "Não é possivel adicionar mais de 30 caracteres")]
        [Display(Name = "Dominio temporário: siteprofissional.somee.com/site/")]
        [Required(ErrorMessage = "O campo Dominio Temporário é requirido!!!")]
        public string DominioTemporario { get; set; }

        [Required(ErrorMessage = "O nome do site é necessário")]
        [Display(Name = "Nome do site")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual Servico Servico { get; set; }
        [JsonIgnore]
        public virtual DateTime Datapedido { get; set; }

        public int DiasLiberados { get { return diasLiberados; } set { diasLiberados = value; } }

        [DataType(DataType.Url)]
        public string Facebook { get; set; }

        [DataType(DataType.Url)]
        public string Twiter { get; set; }

        [DataType(DataType.Url)]
        public string Instagram { get; set; }

        [Required]
        public virtual string ClienteId { get; set; }

        [JsonIgnore]
        public virtual List<PastaImagem> Pastas { get; set; }

        [JsonIgnore]
        public virtual List<Pagina> Paginas { get; set; }
        
        public string Status { get; set; }

        
    }
}
