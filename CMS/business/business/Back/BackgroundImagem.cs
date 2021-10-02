using business.business.Elementos.imagem;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        private CmsContext banco = new CmsContext();

        public virtual Imagem Imagem { get; set; }

        public string RetornaImagem(int id)
        {
            var background =  banco.BackgroundImagens.Include(b => b.Imagem).ToList().FirstOrDefault(b => b.Id == id);

            if (background != null)
                return background.Imagem.ArquivoImagem;
            else return "";
        }
    }
}
