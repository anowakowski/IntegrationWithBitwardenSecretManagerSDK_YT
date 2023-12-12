namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Exceptions
{
    public class OrganizationNotExistException : Exception
    {
        public OrganizationNotExistException(string message)
            : base(message)
        {
            
        }

        public OrganizationNotExistException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
