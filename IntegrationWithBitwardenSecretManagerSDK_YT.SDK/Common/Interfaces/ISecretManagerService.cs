using IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Models;

namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Common.Interfaces
{
    public interface ISecretManagerService
    {
        (bool isAuthenticated, string message) AuthorizeInBitwardenSecureManger(string accessToken);

        SecretModel GetSecret(SecretRequestModel model);

        void Dispose();
    }
}
