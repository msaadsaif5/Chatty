using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatty.Infrastructure
{
    public interface IChattyClient
    {
        Task ReceiveMessage(string user, string message);
    }
}
