
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MeuProjetoAgora.Models.business
{
   public class BackgroundGradiente
    {
        [Key, ForeignKey("Background")]
        public int IdBackgroundGradiente { get; set; }
        [Display(Name = "Grau do Background Gradiente.")]
        public int Grau { get; set; }
        public List<Cor> Cores { get; set; }       
        public virtual Background Background { get; set; }

    }
}
