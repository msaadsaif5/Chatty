using Chatty.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatty.Hubs
{
    public class ChatHub : Hub<IChattyClient>
    {
        public Task BroadcastMessage(string message)
        {
            return Clients.All.ReceiveMessage(GetUserName(), message);
        }

        public void SendMessageToOthers(string message)
        {
            Clients.Others.ReceiveMessage(GetUserName(), message);
        }

        public void SendMessageToCaller(string message)
        {
            Clients.Caller.ReceiveMessage(GetUserName(), message);
        }

        private string GetUserName()
        {
            return Context.User?.Identity?.Name ?? "anonymous";
        }
    }
}
