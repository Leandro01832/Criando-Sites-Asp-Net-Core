using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace MeuProjetoAgora.Models.Repository
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpContextAccessor contextAccessor;
        public IConfiguration Configuration { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public HttpHelper(IHttpContextAccessor contextAccessor
            , IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            this.contextAccessor = contextAccessor;
            Configuration = configuration;
            UserManager = userManager;
        }

        public int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32($"pedidoId_{GetClienteId()}");
        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32($"pedidoId_{GetClienteId()}", pedidoId);
        }

        public void ResetPedidoId()
        {
            contextAccessor.HttpContext.Session.Remove($"pedidoId_{GetClienteId()}");
        }

        private string GetClienteId()
        {
            var claimsPrincipal = contextAccessor.HttpContext.User;
            return UserManager.GetUserId(claimsPrincipal);
        }
    }
}
