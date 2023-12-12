using Bitwarden.Sdk;
using IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Common.Interfaces;
using IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Extensions;
using IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Models;

namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Services
{
    public class SecretManagerService : ISecretManagerService, IDisposable 
    {
        BitwardenClient _bitwardenClient;
        bool _disposed = false;

        public (bool isAuthenticated, string message) AuthorizeInBitwardenSecureManger(string accessToken)
        {
            try
            {
                _bitwardenClient = new BitwardenClient();
                _bitwardenClient.AccessTokenLogin(accessToken);
                _disposed = false;

                return (true, "successfuly autenticated on bitwadren secret manager");
            }
            catch(BitwardenAuthException ex)
            {
                return (false, $"Problem with authenticate with bitwarden secure manager, error message: {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Error during authenticate with bitwarden secure manager, error message: {ex.Message}");
            }

        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _bitwardenClient.Dispose();
            }
        }

        public SecretModel GetSecret(SecretRequestModel model)
        {
            var modelInteral = SecretRequestInternalModel.Create(model, _bitwardenClient);

            modelInteral
                .UserIsAuthorizedOnBitwardenSecretManagerValidation(_disposed)
                .OgranizationExistsValidation()
                .ProjectExistsValidation()
                .SecretSetAndValidation();

            var secretId = modelInteral.Secret.Id;
            var secretRespone = _bitwardenClient.Secrets.Get(secretId);

            return new SecretModel(secretRespone.Value);
        }
    }
}
