using Salesforce.MarketingCloud.Client;

namespace Salesforce.MarketingCloud.Exceptions
{
    public class ServiceUnavailableException : ApiException
    {
        public ServiceUnavailableException(string requestId, int errorCode, string message, dynamic errorContent = null) : base(requestId, errorCode, message)
        {
            this.ErrorContent = errorContent;
        }
    }
}