using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CryptoWebsite.Models;
using Microsoft.Extensions.Options;

namespace CryptoWebsite.Extensions
{
    public static class BuilderExtensions
    {
        public static void ConfigureKeyVault(this IConfigurationBuilder config)
        {
            string? keyVaultEndpoint = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");

            if (keyVaultEndpoint is null)
                throw new InvalidOperationException("Store the Key Vault endpoint in a KEYVAULT_ENDPOINT environment variable.");

            SecretClient? secretClient = new SecretClient(new(keyVaultEndpoint), new DefaultAzureCredential());
            config.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
        }
    }
}
