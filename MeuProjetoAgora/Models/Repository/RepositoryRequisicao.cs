using Microsoft.AspNetCore.Identity;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuProjetoAgora.Models.ViewModels;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryRequisicao
    {
        Task<Requisicao> GetRequisicao();
        Task AddItemAsync(string codigo);
        Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemRequisicao itemPedido);
        Task<Requisicao> UpdateCadastroAsync(Cadastro cadastro);
    }



    public class RepositoryRequisicao : BaseRepository<Requisicao>, IRepositoryRequisicao
    {

        public RepositoryRequisicao(IConfiguration configuration, ApplicationDbContext contexto,
            IHttpHelper httpHelper, IHttpContextAccessor ContextAccessor,
            UserManager<AppIdentityUser> userManager, IRepositoryCadastro repositoryCadastro)
            : base(configuration, contexto)
        {
            HttpHelper = httpHelper;
            contextAccessor = ContextAccessor;
            UserManager = userManager;
            RepositoryCadastro = repositoryCadastro;
        }

        public IHttpHelper HttpHelper { get; }
        public IHttpContextAccessor contextAccessor { get; }
        public UserManager<AppIdentityUser> UserManager { get; }
        public IRepositoryCadastro RepositoryCadastro { get; }

        public async Task AddItemAsync(string codigo)
        {
            var produto = await
                            contexto.Set<Produto>()
                            .Where(p => p.Codigo == codigo)
                            .SingleOrDefaultAsync();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetRequisicao();

            var itemPedido = await
                                contexto.Set<ItemRequisicao>()
                                .Where(i => i.produto.Codigo == codigo
                                        && i.Requisicao.IdRequisicao == pedido.IdRequisicao)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
             //   itemPedido = new ItemRequisicao(pedido, produto, 1, produto.Preco);
                //await
                //    contexto.Set<ItemRequisicao>()
                //    .AddAsync(itemPedido);

                await contexto.SaveChangesAsync();
            }
        }

        public async Task<Requisicao> GetRequisicao()
        {
            var pedidoId = HttpHelper.GetRequisicaoId();
            var pedido =
                await dbSet
                .Include(p => p.ItemRequisicao)
                    .ThenInclude(i => i.produto)
                .Include(p => p.Cadastro)
                .Where(p => p.IdRequisicao == pedidoId)
                .SingleOrDefaultAsync();

            if (pedido == null)
            {
                var claimsPrincipal = contextAccessor.HttpContext.User;
                var clienteId = UserManager.GetUserId(claimsPrincipal);
                pedido = new Requisicao(clienteId);
                await dbSet.AddAsync(pedido);
                await contexto.SaveChangesAsync();
                HttpHelper.SetPedidoId(pedido.IdRequisicao);
            }

            return pedido;
        }

        public async Task<Requisicao> UpdateCadastroAsync(Cadastro cadastro)
        {
            var pedido = await GetRequisicao();
            await RepositoryCadastro.UpdateAsync(pedido.Cadastro.IdCadastro, cadastro);
            HttpHelper.ResetRequisicaoId();
            return pedido;
        }

        public async Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemRequisicao itemPedido)
        {
            var itemPedidoDB = await GetItemPedidoAsync(itemPedido.IdItem);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    await RemoveItemPedidoAsync(itemPedido.IdItem);
                }

                await contexto.SaveChangesAsync();

                var pedido = await GetRequisicao();
                var carrinhoViewModel = new CarrinhoViewModel(pedido.ItemRequisicao);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        private async Task<ItemRequisicao> GetItemPedidoAsync(int itemPedidoId)
        {
            return
            await contexto.Set<ItemRequisicao>()
                .Where(ip => ip.IdItem == itemPedidoId)
                .SingleOrDefaultAsync();
        }

        private async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            contexto.Set<ItemRequisicao>()
                .Remove(await GetItemPedidoAsync(itemPedidoId));
        }


    }
}
