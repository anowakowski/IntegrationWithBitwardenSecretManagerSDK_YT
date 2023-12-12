namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Models
{
    public class SecretRequestModel
    {
        public Guid OrganizationId { get; private set; }
        public string SecretKey { get; private set; }
        public string ProjectName { get; private set; }

        public SecretRequestModel(Guid organizationId, string secretKey, string projectName)
        {
            OrganizationId = organizationId;
            SecretKey = secretKey;
            ProjectName = projectName;
        }
    }
}
