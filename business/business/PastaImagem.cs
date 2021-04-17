
using MeuProjetoAgora.business.Elementos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeuProjetoAgora.business
{
    public class PastaImagem
    {
        [Key]
        public int IdPastaImagem { get; set; }
        public string Nome { get; set; }
        public int PaginaId { get; set; }
        public Pagina Pagina { get; set; }
        public List<Imagem> Imagens { get; set; }
    }
}