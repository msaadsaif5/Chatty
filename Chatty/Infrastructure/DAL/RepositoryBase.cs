using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatty.Data;
using Chatty.Infrastructure.Models;
using Chatty.Migrations;
using Chatty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace Chatty.Infrastructure.DAL
{

    public class RepositoryBase<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly ApplicationDbContext Context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<T> AddAsync(T item)
        {
            var entry = await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return entry.Entity;
        }

        public Task DeleteAsync(T item)
        {
            Context.Attach(item).State = EntityState.Deleted;
            return Context.SaveChangesAsync();
        }

        public Task UpdateAsync(T item)
        {
            var entity = Context.Entry(item).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task<T> GetAsync(TKey id)
        {
            return Context.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}