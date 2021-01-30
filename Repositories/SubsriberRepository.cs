using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.Repositories
{
    public class SubscriberRepository :  ISubscriberRepository
    {
        private readonly ReaiotDbContext _reaiotDbContext;
        public SubscriberRepository(ReaiotDbContext reaiotDbContext)
        {
            _reaiotDbContext = reaiotDbContext;
        } 

        public Task Add(Subscriber subscriber)
        {
            _reaiotDbContext.Add(subscriber);
            return _reaiotDbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            _reaiotDbContext.Remove(_reaiotDbContext.Subscribers.Find(id));
            return _reaiotDbContext.SaveChangesAsync();
        }
        public Subscriber GetById(int id)
        {
            return _reaiotDbContext.Subscribers.Find(id);
        }

        public IEnumerable<Subscriber> GetAll()
        {
            return _reaiotDbContext.Subscribers;
        }

        public Task Update(Subscriber subscriber)
        {
            _reaiotDbContext.Update(subscriber);
            return _reaiotDbContext.SaveChangesAsync();
        }
    }
}
