using ReaiotBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.IRepositories
{
    public interface  ISubscriberRepository
    {
        Task Add (Subscriber help);
        IEnumerable<Subscriber> GetAll();
        Help GetById(int id);
        Task Delete(int id);
        Task Update(Subscriber help);
    }
}
