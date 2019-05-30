using System;
using Newtonsoft.Json.Linq;

namespace Salesforce.MarketingCloud.Test
{
    public static class ApiTestSutFactory<T>
    {
        private static string authBasePath;
        private static string clientId;
        private static string clientSecret;
        private static string accountId;

        static ApiTestSutFactory()
        {
            var accountDetailsEnvironmentVariableValue = GetAccountDetailsEnvironmentVariableValue();
            var accountDetails = JObject.Parse(accountDetailsEnvironmentVariableValue);
            authBasePath = accountDetails["authBasePath"].Value<string>();
            clientId = accountDetails["clientId"].Value<string>();
            clientSecret = accountDetails["clientSecret"].Value<string>();
            accountId = accountDetails["accountId"].Value<string>();
        }

        private static string GetAccountDetailsEnvironmentVariableValue()
        {
            var accountDetailsEnvironmentVariableName = "SFMC_ACCOUNT_DETAILS";

            var accountDetailsEnvironmentVariableValue =
                Environment.GetEnvironmentVariable(accountDetailsEnvironmentVariableName,
                    EnvironmentVariableTarget.Machine);
            if (accountDetailsEnvironmentVariableValue != null)
            {
                return accountDetailsEnvironmentVariableValue;
            }

            accountDetailsEnvironmentVariableValue =
                Environment.GetEnvironmentVariable(accountDetailsEnvironmentVariableName,
                    EnvironmentVariableTarget.User);
            if (accountDetailsEnvironmentVariableValue != null)
            {
                return accountDetailsEnvironmentVariableValue;
            }

            accountDetailsEnvironmentVariableValue =
                Environment.GetEnvironmentVariable(accountDetailsEnvironmentVariableName,
                    EnvironmentVariableTarget.Process);
            if (accountDetailsEnvironmentVariableValue != null)
            {
                return accountDetailsEnvironmentVariableValue;
            }

            throw new NullReferenceException($"Env variable {accountDetailsEnvironmentVariableName} missing.");
        }

        internal static T Create()
        {
            return (T)Activator.CreateInstance(typeof(T), authBasePath, clientId, clientSecret, accountId);
        }
    }
}