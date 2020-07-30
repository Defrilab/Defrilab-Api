using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaiotBackend.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private ReaiotDbContext _dbContext;
        public BaseRepository(ReaiotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T model)
        {
            _dbContext.Add(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T model)
        {
            _dbContext.Remove(model);
            await  _dbContext.SaveChangesAsync();
        }

        public  IEnumerable<T> GetAll()
        {
            return  _dbContext.Set<T>();
        }

        public T GetById(int id, Func<IQueryable<T>, IIncludableQueryable<T,
                                                             object>> includes)
        {
            IQueryable<T> queryable = _dbContext.Set<T>().AsNoTracking();

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return queryable.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public  async Task UpdateAsync(T model)
        {
            _dbContext.Update(model);
            await  _dbContext.SaveChangesAsync();
        }
    }
}
