namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Models
{
    public class SecretModel
    {
        public string SecretValue { get; private set; }

        public SecretModel(string secretValue)
        {
            SecretValue = secretValue;
        }
    }
}
