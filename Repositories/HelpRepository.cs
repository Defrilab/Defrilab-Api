using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.Repositories
{
    public class HelpRepository : IHelpRepository
    {
        private readonly ReaiotDbContext _reaiotDbContext;
        public HelpRepository(ReaiotDbContext reaiotDbContext)
        {
            _reaiotDbContext = reaiotDbContext;
        } 

        public Task AddHelpRequest(Help help)
        {
            _reaiotDbContext.Add(help);
            return _reaiotDbContext.SaveChangesAsync();
        }

        public Task DeleteHelpRequest(int id)
        {
            _reaiotDbContext.Remove(_reaiotDbContext.Help.Find(id));
            return _reaiotDbContext.SaveChangesAsync();
        }
        public Help GetHelpRequestById(int id)
        {
            return _reaiotDbContext.Help.Find(id);
        }

        public IEnumerable<Help> GetHelpRequests()
        {
            return _reaiotDbContext.Help;
        }

        public Task UpdateHelpRequest(Help help)
        {
            _reaiotDbContext.Update(help);
            return _reaiotDbContext.SaveChangesAsync();
        }
    }
}
