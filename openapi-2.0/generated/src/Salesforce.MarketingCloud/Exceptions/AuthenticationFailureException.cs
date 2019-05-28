using Salesforce.MarketingCloud.Client;

namespace Salesforce.MarketingCloud.Exceptions
{
    public class AuthenticationFailureException : ApiException
    {
        public AuthenticationFailureException(string requestId, int errorCode, string message, dynamic errorContent = null) : base(requestId, errorCode, message)
        {
            this.ErrorContent = errorContent;
        }
    }
}