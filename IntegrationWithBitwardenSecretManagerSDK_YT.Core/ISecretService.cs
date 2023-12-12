using IntegrationWithBitwardenSecretManagerSDK_YT.Core.DTOs;

namespace IntegrationWithBitwardenSecretManagerSDK_YT.Core
{
    public interface ISecretService
    {
        SecretResponseDTO GetSecretValue(string secretName, string projectName);
    }
}
