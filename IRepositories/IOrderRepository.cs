using ReaiotBackend.Models.services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.IRepositories
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        Task Delete(int id);
        Task Update(Order order);
    }
}
