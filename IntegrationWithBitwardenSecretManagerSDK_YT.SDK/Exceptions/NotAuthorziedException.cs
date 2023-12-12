namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Exceptions
{
    public class NotAuthorziedException : Exception
    {
        public NotAuthorziedException(string message)
            : base(message)
        {
            
        }

        public NotAuthorziedException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
