using System;

namespace Salesforce.MarketingCloud.Test
{
    public static class ApiTestSutFactory<T>
    {
        private static string authBasePath;
        private static string clientId;
        private static string clientSecret;
        private static string accountId;
        private static string scope;

        static ApiTestSutFactory()
        {
            authBasePath = GetAccountDetailsEnvironmentVariableValue("SFMC_AUTH_BASE_PATH");
            clientId = GetAccountDetailsEnvironmentVariableValue("SFMC_CLIENT_ID");
            clientSecret = GetAccountDetailsEnvironmentVariableValue("SFMC_CLIENT_SECRET");
            accountId = GetAccountDetailsEnvironmentVariableValue("SFMC_ACCOUNT_ID");
            scope = GetAccountDetailsEnvironmentVariableValue("SFMC_SCOPE");
        }

        private static string GetAccountDetailsEnvironmentVariableValue(string envVariableName)
        {
            var accountDetailsEnvironmentVariableValue =
                Environment.GetEnvironmentVariable(envVariableName,
                    EnvironmentVariableTarget.Machine);
            if (accountDetailsEnvironmentVariableValue != null)
            {
                return accountDetailsEnvironmentVariableValue;
            }

            accountDetailsEnvironmentVariableValue =
                Environment.GetEnvironmentVariable(envVariableName,
                    EnvironmentVariableTarget.User);
            if (accountDetailsEnvironmentVariableValue != null)
            {
                return accountDetailsEnvironmentVariableValue;
            }

            accountDetailsEnvironmentVariableValue =
                Environment.GetEnvironmentVariable(envVariableName,
                    EnvironmentVariableTarget.Process);
            if (accountDetailsEnvironmentVariableValue != null)
            {
                return accountDetailsEnvironmentVariableValue;
            }

            throw new NullReferenceException($"Env variable {envVariableName} missing.");
        }

        internal static T Create()
        {
            return (T)Activator.CreateInstance(typeof(T), authBasePath, clientId, clientSecret, accountId, scope);
        }
    }
}