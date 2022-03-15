using business.business.Elementos.imagem;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace business.Back
{
    public class BackgroundImagem : Background
    {
        [Display(Name = "Tipo de repetição do plano de fundo")]
        public string Background_Repeat { get; set; }

        [Display(Name = "Posição do plano de fundo")]
        public string Background_Position { get; set; }
        
    }
}
