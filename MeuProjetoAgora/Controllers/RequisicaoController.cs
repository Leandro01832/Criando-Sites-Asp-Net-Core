using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business;
using MeuProjetoAgora.Models.Repository;
using MeuProjetoAgora.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MeuProjetoAgora.Models;

namespace MeuProjetoAgora.Controllers
{
    public class RequisicaoController : Controller
    {
        public ApplicationDbContext ApplicationDbContext { get; }
        public IRepositoryRequisicao RepositoryRequisicao { get; }
        public IRepositoryProduto RepositoryProduto { get; }
        public UserManager<AppIdentityUser> userManager { get; }

        public RequisicaoController(ApplicationDbContext applicationDbContext, IRepositoryRequisicao repositoryRequisicao,
             IRepositoryProduto repositoryProduto, UserManager<AppIdentityUser> UserManager)
        {
            ApplicationDbContext = applicationDbContext;
            RepositoryRequisicao = repositoryRequisicao;
            RepositoryProduto = repositoryProduto;
            userManager = UserManager;
        }

        public async Task<IActionResult> BuscaProdutos(string pesquisa)
        {
            return View(await RepositoryProduto.GetProdutosAsync(pesquisa));
        }

        [Authorize]
        public async Task<IActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await RepositoryRequisicao.AddItemAsync(codigo);
            }

            var pedido = await RepositoryRequisicao.GetRequisicao();
            List<ItemRequisicao> itens = pedido.ItemRequisicao;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Cadastro()
        {
            var pedido = await RepositoryRequisicao.GetRequisicao();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            var usuario = await userManager.GetUserAsync(this.User);

            pedido.Cadastro.Email = usuario.Email;
            pedido.Cadastro.Telefone = usuario.Telefone;
            pedido.Cadastro.Nome = usuario.Nome;
            pedido.Cadastro.Endereco = usuario.Endereco;
            pedido.Cadastro.Complemento = usuario.Complemento;
            pedido.Cadastro.Bairro = usuario.Bairro;
            pedido.Cadastro.Municipio = usuario.Municipio;
            pedido.Cadastro.UF = usuario.UF;
            pedido.Cadastro.CEP = usuario.CEP;

            return View(pedido.Cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                var usuario = await userManager.GetUserAsync(this.User);

                usuario.Email = cadastro.Email;
                usuario.Telefone = cadastro.Telefone;
                usuario.Nome = cadastro.Nome;
                usuario.Endereco = cadastro.Endereco;
                usuario.Complemento = cadastro.Complemento;
                usuario.Bairro = cadastro.Bairro;
                usuario.Municipio = cadastro.Municipio;
                usuario.UF = cadastro.UF;
                usuario.CEP = cadastro.CEP;

                await userManager.UpdateAsync(usuario);

                return View(await RepositoryRequisicao.UpdateCadastroAsync(cadastro));
            }
            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<UpdateQuantidadeResponse> UpdateQuantidade([FromBody]ItemRequisicao itemPedido)
        {
            return await RepositoryRequisicao.UpdateQuantidadeAsync(itemPedido);
        }
    }
}