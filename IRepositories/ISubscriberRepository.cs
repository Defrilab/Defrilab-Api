using ReaiotBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.IRepositories
{
    public interface  ISubscriberRepository
    {
        Task Add (Subscriber subscriber);
        IEnumerable<Subscriber> GetAll();
        Subscriber GetById(int id);
        Task Delete(int id);
        Task Update(Subscriber  subscriber);
    }
}
