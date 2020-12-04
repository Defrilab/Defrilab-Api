using Microsoft.Extensions.Configuration;
using ReaiotBackend.Dtos;
using System.Text;

namespace ReaiotBackend.Services
{
    public class BlobStorageService
    {
        private IConfiguration Configuration { get;  }
        public string GetCredentials()
        {
            var reaiotConfiguration =  Configuration.GetSection("ReaiotBlobStorageDetails");
            var reaiotCredentials = reaiotConfiguration.Get<ReaiotCredentials>();
            var connectionString = Encoding.ASCII.GetBytes(reaiotCredentials.ConnectionString).ToString();
            var credentials = new ReaiotCredentials()
            {
                ConnectionString = connectionString,
            };
            return credentials.ConnectionString;
        }
    }
}
