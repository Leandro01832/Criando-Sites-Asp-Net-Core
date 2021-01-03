
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models
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
