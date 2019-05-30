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
            var accountDetailsEnvironmentVariableName = "SFMC_ACCOUNT_DETAILS";
            var accountDetailsEnvironmentVariableValue =
                Environment.GetEnvironmentVariable(accountDetailsEnvironmentVariableName,
                    EnvironmentVariableTarget.Machine);
            if (accountDetailsEnvironmentVariableValue == null)
            {
                throw new NullReferenceException($"System Env variable {accountDetailsEnvironmentVariableName} missing.");
            }
            var accountDetails = JObject.Parse(accountDetailsEnvironmentVariableValue);
            authBasePath = accountDetails["authBasePath"].Value<string>();
            clientId = accountDetails["clientId"].Value<string>();
            clientSecret = accountDetails["clientSecret"].Value<string>();
            accountId = accountDetails["accountId"].Value<string>();
        }

        internal static T Create()
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { authBasePath, clientId, clientSecret, accountId });
        }
    }
}