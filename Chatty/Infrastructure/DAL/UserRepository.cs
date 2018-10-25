using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatty.Data;
using Chatty.Infrastructure.Models;
using Chatty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Chatty.Infrastructure.DAL
{   
    public class UserRepository: RepositoryBase<ApplicationUser, string>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<ApplicationUser>> GetOnlineUsersAsync(UserFilterCriteria criteria)
        {            
            if (criteria == null)
                return await Context.ApplicationUser.AsNoTracking().ToListAsync();
            
            var users = Context.ApplicationUser.AsNoTracking();
            if (criteria.IsOnline.HasValue)
            {
                users = users.Where(usr => usr.SignedIn);
            }

            if (!String.IsNullOrEmpty(criteria.Name))
            {
                users = users.Where(usr => usr.Name.Contains(criteria.Name));
            }

            return await users.ToListAsync();
        }
    }
}