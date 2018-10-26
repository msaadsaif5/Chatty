using Chatty.Hubs;
using Chatty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatty.Infrastructure.DAL;
using Chatty.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Chatty.Migrations;

namespace Chatty.Infrastructure.Components
{
    public class OnlineUsersViewComponent : ViewComponent
    {
        private readonly IHubContext<ChatHub> hub;
        private readonly IUserRepository userRepository;
        

        public OnlineUsersViewComponent(IHubContext<ChatHub> hub, IUserRepository userRepository)
        {
            this.hub = hub;
            this.userRepository = userRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var onlineUsers = await userRepository.GetFilteredUsersAsync(new UserFilterCriteria {IsOnline = true});
            var model = onlineUsers.Select(usr => new OnlineUserViewModel {Id = usr.Email, IsOnline = true, Name = usr.Name});
            return View(model);
        }
    }
}
