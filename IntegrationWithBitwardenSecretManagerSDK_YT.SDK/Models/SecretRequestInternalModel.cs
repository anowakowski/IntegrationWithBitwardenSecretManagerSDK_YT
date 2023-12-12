using Bitwarden.Sdk;

namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Models
{
    public class SecretRequestInternalModel : SecretRequestModel
    {
        public BitwardenClient BitwardenCln { get; private set; }
        public SecretIdentifierResponse Secret { get; set; }
        private SecretRequestInternalModel(Guid organizationId, string secretKey, string projectName, BitwardenClient bitwardenClient) : base(organizationId, secretKey, projectName)
        {
            BitwardenCln = bitwardenClient;
        }

        public static SecretRequestInternalModel Create(SecretRequestModel model, BitwardenClient bitwardenClient) => new SecretRequestInternalModel(model.OrganizationId, model.SecretKey, model.ProjectName, bitwardenClient);
    }
}
