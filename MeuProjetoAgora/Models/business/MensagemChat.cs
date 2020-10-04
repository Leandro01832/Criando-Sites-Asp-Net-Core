using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.business
{
   public class MensagemChat
    {
        [Key]
        public int IdMensagem { get; set; }
        public int Pagina { get; set; }
        public string NomeUsuario { get; set; }
        public string Mensagem { get; set; }
    }
}
