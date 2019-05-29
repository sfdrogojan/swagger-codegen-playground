using Salesforce.MarketingCloud.Client;

namespace Salesforce.MarketingCloud.Exceptions
{
    public class ResourceNotFoundException : ApiException
    {
        public ResourceNotFoundException(string requestId, int errorCode, string message, dynamic errorContent = null) : base(requestId, errorCode, message)
        {
            this.ErrorContent = errorContent;
        }
    }
}