using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chatty.Infrastructure.Models;
using Chatty.Models;

namespace Chatty.Infrastructure.DAL
{
    public interface IUserRepository : IRepository<ApplicationUser, string>
    {
        Task<IEnumerable<ApplicationUser>> GetOnlineUsersAsync(UserFilterCriteria criteria);
    }
}