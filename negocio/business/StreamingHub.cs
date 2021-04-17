using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.business
{
    public class StreamingHub : Hub
    {
        public async Task SendMessage(string user, string messagem)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, messagem);
        }
    }
}
