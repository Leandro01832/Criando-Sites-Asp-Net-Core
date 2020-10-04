using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.business
{
    public class Rota
    {
        [Key]
        public int IdRota { get; set; }
        public string NomeRota { get; set; }
    }
}
