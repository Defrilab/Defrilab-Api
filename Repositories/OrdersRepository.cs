using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ReaiotDbContext _reaiotDbContext;
        public OrderRepository(ReaiotDbContext reaiotDbContext)
        {
            _reaiotDbContext = reaiotDbContext;
        }

        public Task Add(Order order)
        {
            _reaiotDbContext.Add(order);
            return _reaiotDbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            _reaiotDbContext.Remove(_reaiotDbContext.Orders.Find(id));
            return _reaiotDbContext.SaveChangesAsync();
        }
        public Order GetById(int id)
        {
            return _reaiotDbContext.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _reaiotDbContext.Orders;
        }

        public Task Update(Order  order)
        {
            _reaiotDbContext.Update(order);
            return _reaiotDbContext.SaveChangesAsync();
        }
    }
}
