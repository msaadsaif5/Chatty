using Chatty.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatty.Infrastructure.Components
{
    public class OnlineUsersViewComponent : ViewComponent
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IHubContext<ChatHub> hub;

        public OnlineUsersViewComponent(IHubContext<ChatHub> hub)
        {
            this.hub = hub;
        }

        public Task<IActionResult> InvokeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
