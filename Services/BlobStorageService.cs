using Microsoft.Extensions.Configuration;
using ReaiotBackend.Dtos;
using System.Text;

namespace ReaiotBackend.Services
{
    public class BlobStorageService
    {
        public IConfiguration Configuration { get;  }
        public BlobStorageService(IConfiguration configuration)
        {
            Configuration = configuration;
            GetCredentials();
        }
        private object GetCredentials()
        {
            var reaiotConfiguration =  Configuration.GetSection("ReaiotBlobStorageDetails");
            var reaiotCredentials = reaiotConfiguration.Get<ReaiotCredentials>();
            var connectionString = Encoding.ASCII.GetBytes(reaiotCredentials.ConnectionString1).ToString();
            var key1 = Encoding.ASCII.GetBytes(reaiotCredentials.Key1).ToString();
            var credentials = new ReaiotCredentials()
            {
                ConnectionString1 = connectionString, 
                Key1 = key1 
            };
            return credentials;
        }
    }
}
