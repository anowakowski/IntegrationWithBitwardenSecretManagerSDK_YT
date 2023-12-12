namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Exceptions
{
    public class ProjectNotExistException : Exception
    {
        public ProjectNotExistException(string message)
            : base(message)
        {
            
        }

        public ProjectNotExistException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
