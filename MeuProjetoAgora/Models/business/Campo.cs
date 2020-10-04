using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using MeuProjetoAgora.Models.business;

namespace MeuProjetoAgora.Models.business
{
    public class Campo
    {
        [Key]
        public int IdCampo { get; set; }
        public string Nome { get; set; }

        public string Placeholder { get; set; }
        public string Tipo { get; set; }
        [JsonIgnore]
        public virtual Formulario formulario { get; set; }

    }
}