using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using Salesforce.MarketingCloud.Client;
using Salesforce.MarketingCloud.Exceptions;
using UnauthorizedAccessException = Salesforce.MarketingCloud.Exceptions.UnauthorizedAccessException;

namespace Salesforce.MarketingCloud.UnitTests
{
    [TestFixture]
    public class ExceptionFactoryTests
    {
        private string ApiMethod = "ApiMethod";

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIsBadRequest_ReturnsBadRequestException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.BadRequest, "Bad request");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(400, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Bad request", exception.ErrorContent);
            Assert.IsInstanceOf<BadRequestException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIsUnauthorized_ReturnsAuthenticationFailureException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(401, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Unauthorized", exception.ErrorContent);
            Assert.IsInstanceOf<AuthenticationFailureException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIsForbidden_ReturnsUnauthorizedAccessException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.Forbidden, "Forbidden");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(403, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Forbidden", exception.ErrorContent);
            Assert.IsInstanceOf<UnauthorizedAccessException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIsResourceNotFound_ReturnsResourceNotFoundException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.NotFound, "Not found");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(404, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Not found", exception.ErrorContent);
            Assert.IsInstanceOf<ResourceNotFoundException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIsInternalServerError_ReturnsInternalServerErrorException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.InternalServerError, "Internal server error");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(500, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Internal server error", exception.ErrorContent);
            Assert.IsInstanceOf<InternalServerErrorException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIsBadGateway_ReturnsBadGatewayException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.BadGateway, "Bad gateway");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(502, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Bad gateway", exception.ErrorContent);
            Assert.IsInstanceOf<BadGatewayException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIsServiceUnavailable_ReturnsServiceUnavailableException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.ServiceUnavailable, "Service unavailable");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(503, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Service unavailable", exception.ErrorContent);
            Assert.IsInstanceOf<ServiceUnavailableException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeInResponseIsGatewayTimeout_ReturnsGatewayTimeoutException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.GatewayTimeout, "Gateway timeout");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(504, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Gateway timeout", exception.ErrorContent);
            Assert.IsInstanceOf<GatewayTimeoutException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenSpecificStatusCodeNotCovered_ReturnsApiException()
        {
            var requestResponse = CreateRequestResponse(HttpStatusCode.HttpVersionNotSupported, "HTTP version not supported");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(505, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("HTTP version not supported", exception.ErrorContent);
            Assert.IsInstanceOf<ApiException>(exception);
        }

        [Test]
        public void DefaultExceptionFactory_WhenStatusCodeIs0_ReturnsApiException()
        {
            var requestResponse = CreateRequestResponse(0, "Server unreachable");
            var exception = (ApiException)Configuration.DefaultExceptionFactory(ApiMethod, requestResponse);

            Assert.AreEqual(0, exception.ErrorCode);
            Assert.AreEqual("Error calling ApiMethod", exception.Message);
            Assert.AreEqual("Server unreachable", exception.ErrorContent);
            Assert.IsInstanceOf<ServerUnreachableException>(exception);
        }

        [Test]
        public void GetRequestIdFromResponse_WhenResponseContainsRequestId_ReturnsRequestId()
        {
            var headerField1 = GetHeaderField("X-Mashery-Responder", "91-t08");
            var headerField2 = GetHeaderField("X-Mashery-Message-ID", "b201e5a8-36f1-4a67-b77f-2acc304a2f6e");
            var headerField3 = GetHeaderField("Server", "Web server type");
            var headerField4 = GetHeaderField("Referrer-Policy", "Policy-type");

            var headerFieldsList = new List<Parameter>
            {
                headerField1,
                headerField2,
                headerField3,
                headerField4
            };

            var requestResponse = CreateRequestResponse(headerFieldsList);

            Assert.AreEqual("b201e5a8-36f1-4a67-b77f-2acc304a2f6e", Configuration.GetRequestIdFromResponse(requestResponse));
        }

        [Test]
        public void GetRequestIdFromResponse_WhenResponseDoesNotContainRequestId_ReturnsNull()
        {
            var headerField1 = GetHeaderField("X-Mashery-Responder", "91-t08");
            var headerField2 = GetHeaderField("Referrer-Policy", "Policy-type");
            var headerField3 = GetHeaderField("Server", "Web server type");

            var headerFieldsList = new List<Parameter>
            {
                headerField1,
                headerField2,
                headerField3,
            };

            var requestResponse = CreateRequestResponse(headerFieldsList);

            Assert.AreEqual(null, Configuration.GetRequestIdFromResponse(requestResponse));
        }

        private Parameter GetHeaderField(string name, string value)
        {
            return new Parameter()
            {
                Name = name,
                Value = value
            };
        }

        private IRestResponse CreateRequestResponse(List<Parameter> headerFieldsList)
        {
            IRestResponse requestResponse = Substitute.For<IRestResponse>();

            requestResponse.Headers.Returns(headerFieldsList);

            return requestResponse;
        }

        private IRestResponse CreateRequestResponse(HttpStatusCode responseHttpStatusCode, string responseContent)
        {
            IRestResponse requestResponse = Substitute.For<IRestResponse>();

            requestResponse.StatusCode.Returns(responseHttpStatusCode);
            requestResponse.Content.Returns($"{responseContent}");

            return requestResponse;
        }

        private IRestResponse CreateRequestResponse(int responseHttpStatusCode, string errorMessage)
        {
            IRestResponse requestResponse = Substitute.For<IRestResponse>();

            requestResponse.StatusCode.Returns((HttpStatusCode)responseHttpStatusCode);
            requestResponse.ErrorMessage.Returns($"{errorMessage}");

            return requestResponse;
        }
    }
}