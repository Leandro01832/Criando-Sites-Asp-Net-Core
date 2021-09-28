using business.business.Elementos.imagem;
using System.ComponentModel.DataAnnotations;

namespace business.Back
{
    public class BackgroundImagem : Background
    {
        [Display(Name = "Tipo de repetição do plano de fundo")]
        public string Background_Repeat { get; set; }

        [Display(Name = "Posição do plano de fundo")]
        public string Background_Position { get; set; }

        [Display(Name = "Imagem do plano de fundo")]
        public int ImagemId { get; set; }

        public virtual Imagem Imagem { get; set; }
    }
}
