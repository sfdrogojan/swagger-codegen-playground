using IO.Swagger.Authenticators;
using IO.Swagger.Client;

namespace IO.Swagger.Test
{
    internal class StubAuthService : AuthService
    {
        internal int getAuthorizationHeaderValueCallsCounter = 0;

        public StubAuthService(Configuration configuration,
            IApiClient apiClient,
            ICacheService cacheService)
            : base(configuration, apiClient, cacheService)
        { 
        }

        public override AuthorizationHeaderValue GetAuthorizationHeaderValue()
        {
            getAuthorizationHeaderValueCallsCounter += 1;

            return base.GetAuthorizationHeaderValue();
        }
    }
}