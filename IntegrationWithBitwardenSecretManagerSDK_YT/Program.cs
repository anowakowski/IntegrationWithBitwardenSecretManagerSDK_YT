using IntegrationWithBitwardenSecretManagerSDK_YT.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfigurationBuilder builder = new ConfigurationBuilder();

builder
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var serviceCollection = new ServiceCollection()
        .AddTransient<ISecretService, SecretService>()
        .AddSingleton<IConfiguration>(builder.Build())
        .BuildServiceProvider();

var service = serviceCollection.GetService<ISecretService>();

var result = service.GetSecretValue("API_KEY", "testowy projekt");

Console.WriteLine(result.IsError ? $"Error during getSecretValue from bitwarden Secure Manager: {result.ErrorMessage}" : $"Your secret value for key \"API_KEY\" is {result.SecretValue}" );
Console.WriteLine("Press any key to close");
Console.ReadLine();
