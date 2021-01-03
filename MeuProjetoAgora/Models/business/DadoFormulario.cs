using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.business
{
    public class DadoFormulario
    {
        [Key]
        public int IdDadoFormulario { get; set; }
        public int Formulario { get; set; }
        public int Campo { get; set; }
        public string Valor { get; set; }
    }
}
