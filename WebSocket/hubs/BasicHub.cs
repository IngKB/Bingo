using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocket.models;

namespace WebSocket.hubs
{
    public class BasicHub: Hub
    {
        public async Task SendMessage(Message mensaje) =>
            await Clients.All.SendAsync("Mensaje recibido", mensaje);
        
    }
}
