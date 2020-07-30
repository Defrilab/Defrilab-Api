using Microsoft.EntityFrameworkCore.Query;
using ReaiotBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  ReaiotBackend.IRepositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task AddAsync(T model);
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(T model);
        Task UpdateAsync(T model);
        T GetById(int id, Func<IQueryable<T>, 
            IIncludableQueryable<T,object>> includes);
    }
}
