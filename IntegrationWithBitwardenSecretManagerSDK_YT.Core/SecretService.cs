using Bitwarden.Sdk;
using IntegrationWithBitwardenSecretManagerSDK_YT.Core.DTOs;
using IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Services;
using Microsoft.Extensions.Configuration;

namespace IntegrationWithBitwardenSecretManagerSDK_YT.Core
{
    public class SecretService : ISecretService
    {
        private readonly IConfiguration _configuration;

        public SecretService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SecretResponseDTO GetSecretValue(string secretName, string projectName)
        {
            var configuration = GetConfiguration();
            var secretValue = string.Empty;

            using(var bwSecretManagerService = new SecretManagerService())
            {
                var result = bwSecretManagerService.AuthorizeInBitwardenSecureManger(configuration.accessToken);

                if (!result.isAuthenticated)
                {
                    var message = result.message;
                    return new SecretResponseDTO(message, true);
                }

                try
                {
                    var secretModel = bwSecretManagerService.GetSecret(new SDK.Models.SecretRequestModel(configuration.organizationId, secretName, projectName));
                    secretValue = secretModel.SecretValue;
                }
                catch(Exception ex)
                {
                    return new SecretResponseDTO(ex.Message, true);
                }

            }

            return new SecretResponseDTO(secretValue); ;
        }

        private (string accessToken, Guid organizationId) GetConfiguration()
        {
            var section = _configuration.GetSection("BitwardenSM");

            if (section == null) throw new ArgumentException("section BitwardenSM doesn't exists in appsettings.json");

            var accessToken = section.GetSection("AccessToken").Value;
            var organizationId = Guid.Parse(section.GetSection("OrganizationId").Value);

            return (accessToken, organizationId);
        }
    }
}
