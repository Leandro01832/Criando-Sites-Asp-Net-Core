using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
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
            .FirstAsync(p => p.Id == id);             

            return PartialView(produto);
        }
    }
}