using business.business.Elementos.element;
using business.business.Elementos.produto;
using System.Collections.Generic;

namespace CMS.Models.ViewModels
{
    public class BuscaProdutosViewModel
    {
        private List<Produto> list;

        public BuscaProdutosViewModel(IList<Elemento> produtos, string pesquisa)
        {
            Produtos = produtos;
            Pesquisa = pesquisa;
        }

        public BuscaProdutosViewModel(List<Produto> list, string pesquisa)
        {
            this.list = list;
            Pesquisa = pesquisa;
        }

        public IList<Elemento> Produtos { get; }
        public string Pesquisa { get; set; }
    }
}
