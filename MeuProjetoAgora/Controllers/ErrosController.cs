using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjetoAgora.Controllers
{
    public class ErrosController : Controller
    {
        private readonly ApplicationDbContext Contexto;

        public ErrosController(ApplicationDbContext context)
        {
            Contexto = context;
        }

        [HttpGet("Error/500")]
        public IActionResult Error500()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                ViewBag.ErrorMessage = exceptionFeature.Error.Message;
                ViewBag.RouteOfException = exceptionFeature.Path;
            }

            return View();
        }

        [HttpGet("Error/{statusCode}")]
        public IActionResult HandleErrorCodeAsync(int statusCode)
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "A página requisitada não foi encontrada";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;                 

                    break;
                case 500:
                    ViewBag.ErrorMessage = "Alguma coisa deu errado no servidor";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;
                    break;
            }

            return View();
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            return View("Error");
        }
    }
}