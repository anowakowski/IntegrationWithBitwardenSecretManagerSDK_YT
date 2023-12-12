using Bitwarden.Sdk;
using IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Exceptions;
using IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Models;

namespace IntegrationWithBitwardenSecretManagerSDK_YT.SDK.Extensions
{
    public static class SecretRequestInternalModelValidationExtension
    {
        public static SecretRequestInternalModel UserIsAuthorizedOnBitwardenSecretManagerValidation(this SecretRequestInternalModel model, bool disposed)
        {
            if (disposed || model.BitwardenCln == null) throw new NotAuthorziedException("You are currently not authorized on bitwarden secret manager");

            return model;
        }

        public static SecretRequestInternalModel OgranizationExistsValidation(this SecretRequestInternalModel model)
        {
            try
            {
                model.BitwardenCln.Projects.List(model.OrganizationId);
                return model;
            }
            catch(BitwardenException ex)
            {
                throw new OrganizationNotExistException($"your organization: {model.OrganizationId} not exists");
            }
        }

        public static SecretRequestInternalModel ProjectExistsValidation(this SecretRequestInternalModel model)
        {
            var projects = model.BitwardenCln.Projects.List(model.OrganizationId);

            var projectsDataList = projects.Data.ToList();

            var foundedProject = projectsDataList.FirstOrDefault(x => x.Name == model.ProjectName);

            if (foundedProject == null) throw new ProjectNotExistException($"project: {model.ProjectName} not exists in your organization");

            return model;
        }

        public static SecretRequestInternalModel SecretSetAndValidation(this SecretRequestInternalModel model)
        {
            var secrets = model.BitwardenCln.Secrets.List(model.OrganizationId);

            if (!secrets.Data.Any()) throw new SecretNotExistException($"you currently haven't any secrets on your organization: {model.OrganizationId}");

            var secret = secrets.Data.FirstOrDefault(x => x.Key == model.SecretKey);

            if (secret == null) throw new SecretNotExistException($"your secret: {model.SecretKey} is not exist in your organization: {model.OrganizationId}");

            model.Secret = secret;

            return model;
        }
    }
}
