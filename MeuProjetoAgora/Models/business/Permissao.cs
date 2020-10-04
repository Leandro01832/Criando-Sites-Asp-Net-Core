using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.business
{
   public class Permissao
    {
        [Key]
        public int IdPermissao { get; set; }
        public string NomePermissao { get; set; }
        public int Site { get; set; }
        public string UserName { get; set; }
    }
}
