using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuProjetoAgora.Controllers
{
    public class FormularioController : Controller
    {
        public FormularioController(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SalvarDados(List<string> valores, int Formulario)
        {
            var formulario = await Db.Form
                .Include(f => f.Despendentes)
                .ThenInclude(f => f.ElementoDependente)
                .ThenInclude(f => f.Dependente)
                .FirstAsync(f => f.IdElemento == Formulario);

            var i = 0;

            foreach (var dependente in formulario.Despendentes)
            {
                var campo = (Campo)dependente.ElementoDependente.Dependente;
                await Db.DadoFormulario.AddAsync(new DadoFormulario {
                    Campo = campo.IdElemento,
                     Formulario = Formulario,
                      Valor = valores[i]
                });
                await Db.SaveChangesAsync();
                i++;
            }

            return Content("Sucesso");
        }
    }
}