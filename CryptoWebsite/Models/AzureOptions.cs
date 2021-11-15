using System.ComponentModel.DataAnnotations;
namespace CryptoWebsite.Models
{
    public class AzureOptions
    {
        [Required]
        public string KEYVAULT_ENDPOINT { get; set; } = null!;
    }
}
