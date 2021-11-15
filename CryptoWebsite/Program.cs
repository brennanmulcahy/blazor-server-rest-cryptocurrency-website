using CryptoWebsite.Extensions;
using CryptoWebsite.Services;
using CryptoWebsite.Models;

var builder = WebApplication.CreateBuilder(args);



// Configure CryptoOptions POCO.
var cryptoOptionsConfig = builder.Configuration.GetSection("CryptoOptions").Get<CryptoOptions>();
CryptoOptions _cryptoOptions;
_cryptoOptions = new CryptoOptions();
_cryptoOptions.ApiKey = cryptoOptionsConfig.ApiKey;

// Configure Azure Key Vault Endpoint.
var azureOptionsConfig = builder.Configuration.GetSection("AzureOptions").Get<AzureOptions>();
AzureOptions _azureOptions;
_azureOptions = new AzureOptions();
_azureOptions.KEYVAULT_ENDPOINT = azureOptionsConfig.KEYVAULT_ENDPOINT;
Environment.SetEnvironmentVariable("KEYVAULT_ENDPOINT", azureOptionsConfig.KEYVAULT_ENDPOINT);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

builder.Services.AddOptions<CryptoOptions>()
    .Bind(builder.Configuration.GetSection(nameof(CryptoOptions)))
    .ValidateDataAnnotations();

builder.Services.AddOptions<AzureService>()
    .Bind(builder.Configuration.GetSection(nameof(AzureOptions)))
    .ValidateDataAnnotations();

builder.Services.AddSingleton<CryptoService>();
builder.Services.AddSingleton<AzureService>();

// Configure Azure Key Vault.
if (builder.Environment.IsProduction())
    builder.Configuration.ConfigureKeyVault(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
