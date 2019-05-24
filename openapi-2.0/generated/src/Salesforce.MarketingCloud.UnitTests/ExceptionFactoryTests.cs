using System.Net;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using Salesforce.MarketingCloud.Client;
using Salesforce.MarketingCloud.Exceptions;

namespace Salesforce.MarketingCloud.UnitTests
{
    [TestFixture]
    public class ExceptionFactoryTests
    {
        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIs404_ReturnsResourceNotFoundException()
        {
        }

        private IRestResponse CreateAuthRequestResponse(HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            IRestResponse authRequestResponse = Substitute.For<IRestResponse>();
            authRequestResponse.Content.Returns(@"{ 
                'access_token': 'access_token', 
                'token_type': 'token_type',
                'expires_in': 1000,
                'rest_instance_url':'https://rest.com',
                'soap_instance_url':'https://soap.com'
            }");

            authRequestResponse.StatusCode.Returns(httpStatusCode);
            return authRequestResponse;
        }
    }
}