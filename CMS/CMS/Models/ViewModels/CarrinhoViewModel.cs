using business.ecommerce;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemRequisicao> itens)
        {
            Itens = itens;
        }

        public IList<ItemRequisicao> Itens { get; }

        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
