
using business.ecommerce;
using CMS.Models.ViewModels;

namespace CMS.Models
{
    public class UpdateQuantidadeResponse
    {
        public UpdateQuantidadeResponse(ItemRequisicao itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            ItemPedido = itemPedido;
            CarrinhoViewModel = carrinhoViewModel;
        }

        public ItemRequisicao ItemPedido { get; }
        public CarrinhoViewModel CarrinhoViewModel { get; }
    }
}
