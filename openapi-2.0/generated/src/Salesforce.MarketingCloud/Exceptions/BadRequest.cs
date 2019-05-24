using Salesforce.MarketingCloud.Client;

namespace Salesforce.MarketingCloud.Exceptions
{
    public class BadRequest : ApiException
    {
        public BadRequest(int errorCode, string message, dynamic errorContent = null) : base(errorCode, message)
        {
            this.ErrorContent = errorContent;
        }
    }
}