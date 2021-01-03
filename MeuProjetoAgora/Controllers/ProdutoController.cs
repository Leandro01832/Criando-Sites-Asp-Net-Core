using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuProjetoAgora.Controllers
{
    public class ProdutoController : Controller
    {
        public ProdutoController(ApplicationDbContext contexto, IRepositoryElemento repositoryElemento)
        {
            Contexto = contexto;
            RepositoryElemento = repositoryElemento;
        }

        public ApplicationDbContext Contexto { get; }
        public IRepositoryElemento RepositoryElemento { get; }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await RepositoryElemento.includes()
            .FirstAsync(p => p.IdElemento == id);             

            return PartialView(produto.Despendentes);
        }
    }
}