using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMS.Models;
using CMS.Models.Repository;
using business.business;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public IRepositoryPagina RepositoryPagina { get; }

        public HomeController(IRepositoryPagina repositoryPagina)
        {
            RepositoryPagina = repositoryPagina;
        }

        [Route("Carousel")]
        [Route("Carrossel")]
        [Route("Pages")]
        [Route("Paginas")]
        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            IList<Pagina> pages = await RepositoryPagina.MostrarPageModels();
            List<Pagina> pages2 = new List<Pagina>();
            foreach (var p in pages.Where(p => p.Exibicao == true))
            {
                p.Html = await RepositoryPagina.renderizarPagina(p);
                pages2.Add(p);
            }

            return View(pages2);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
