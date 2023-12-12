namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Exceptions
{
    public class SecretNotExistException : Exception
    {
        public SecretNotExistException(string message)
            : base(message)
        {
            
        }

        public SecretNotExistException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
