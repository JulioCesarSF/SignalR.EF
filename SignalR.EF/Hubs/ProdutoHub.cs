using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.EF.Hubs
{
    [HubName("produtoHubSignalR")]
    public class ProdutoHub : Hub
    {
        public static void NotificarClientes()
        {
            IHubContext ctx = GlobalHost.ConnectionManager.GetHubContext<ProdutoHub>();

            //dynamic
            ctx.Clients.All.atualizarClientes();
        }
    }
}