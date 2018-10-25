using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatty.Infrastructure.DAL
{

    public interface IRepository<T, TKey> where T : class
    {
        Task<T> AddAsync(T item);
        Task DeleteAsync(T item);
        Task UpdateAsync(T item);
        Task<T> GetAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();        
    }
}