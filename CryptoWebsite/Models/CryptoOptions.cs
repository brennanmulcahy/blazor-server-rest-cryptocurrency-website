using System.ComponentModel.DataAnnotations;
namespace CryptoWebsite.Models
{
    public class CryptoOptions
    {
        [Required]
        public string ApiKey { get; set; } = null!;

        [Required]
        public string Endpoint { get; init; } = null!;
    }
}
