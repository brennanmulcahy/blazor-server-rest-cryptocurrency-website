using CryptoWebsite.Models;
using Microsoft.Extensions.Options;

namespace CryptoWebsite.Services
{
    public class AzureService
    {
        private readonly AzureOptions _azureOptions;

        public AzureService(IOptions<AzureOptions> azureConfiguration)
        {
            _azureOptions = azureConfiguration.Value;
        }
    }
}
