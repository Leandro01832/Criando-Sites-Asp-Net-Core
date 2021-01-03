using MeuProjetoAgora.Models.business.Elemento;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeuProjetoAgora.Models.business
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