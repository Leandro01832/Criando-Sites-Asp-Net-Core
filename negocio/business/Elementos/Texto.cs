
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.business.Elementos
{
   public class Texto : Elemento
    {
        [Display(Name = "Texto")]
        public string PalavrasTexto { get; set; }
    }
}
