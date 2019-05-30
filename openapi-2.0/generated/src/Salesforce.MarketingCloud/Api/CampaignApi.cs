/* 
 * Marketing Cloud REST API
 *
 * Marketing Cloud's REST API is our newest API. It supports multi-channel use cases, is much more lightweight and easy to use than our SOAP API, and is getting more comprehensive with every release.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: mc_sdk@salesforce.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;
using Salesforce.MarketingCloud.Authentication;
using Salesforce.MarketingCloud.Client;
using Salesforce.MarketingCloud.Model;

namespace Salesforce.MarketingCloud.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICampaignApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// createCampaign
        /// </summary>
        /// <remarks>
        /// Creates a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">JSON Parameters (optional)</param>
        /// <returns>Campaign</returns>
        Campaign CreateCampaign (Campaign body = null);

        /// <summary>
        /// createCampaign
        /// </summary>
        /// <remarks>
        /// Creates a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">JSON Parameters (optional)</param>
        /// <returns>ApiResponse of Campaign</returns>
        ApiResponse<Campaign> CreateCampaignWithHttpInfo (Campaign body = null);
        /// <summary>
        /// deleteCampaign
        /// </summary>
        /// <remarks>
        /// Deletes a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The ID of the campaign to delete</param>
        /// <returns></returns>
        void DeleteCampaignById (decimal? id);

        /// <summary>
        /// deleteCampaign
        /// </summary>
        /// <remarks>
        /// Deletes a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The ID of the campaign to delete</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteCampaignByIdWithHttpInfo (decimal? id);
        /// <summary>
        /// getCampaign
        /// </summary>
        /// <remarks>
        /// Retrieves a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Campaign ID</param>
        /// <returns>Campaign</returns>
        Campaign GetCampaignById (decimal? id);

        /// <summary>
        /// getCampaign
        /// </summary>
        /// <remarks>
        /// Retrieves a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Campaign ID</param>
        /// <returns>ApiResponse of Campaign</returns>
        ApiResponse<Campaign> GetCampaignByIdWithHttpInfo (decimal? id);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// createCampaign
        /// </summary>
        /// <remarks>
        /// Creates a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">JSON Parameters (optional)</param>
        /// <returns>Task of Campaign</returns>
        System.Threading.Tasks.Task<Campaign> CreateCampaignAsync (Campaign body = null);

        /// <summary>
        /// createCampaign
        /// </summary>
        /// <remarks>
        /// Creates a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">JSON Parameters (optional)</param>
        /// <returns>Task of ApiResponse (Campaign)</returns>
        System.Threading.Tasks.Task<ApiResponse<Campaign>> CreateCampaignAsyncWithHttpInfo (Campaign body = null);
        /// <summary>
        /// deleteCampaign
        /// </summary>
        /// <remarks>
        /// Deletes a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The ID of the campaign to delete</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteCampaignByIdAsync (decimal? id);

        /// <summary>
        /// deleteCampaign
        /// </summary>
        /// <remarks>
        /// Deletes a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The ID of the campaign to delete</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteCampaignByIdAsyncWithHttpInfo (decimal? id);
        /// <summary>
        /// getCampaign
        /// </summary>
        /// <remarks>
        /// Retrieves a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Campaign ID</param>
        /// <returns>Task of Campaign</returns>
        System.Threading.Tasks.Task<Campaign> GetCampaignByIdAsync (decimal? id);

        /// <summary>
        /// getCampaign
        /// </summary>
        /// <remarks>
        /// Retrieves a campaign.
        /// </remarks>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Campaign ID</param>
        /// <returns>Task of ApiResponse (Campaign)</returns>
        System.Threading.Tasks.Task<ApiResponse<Campaign>> GetCampaignByIdAsyncWithHttpInfo (decimal? id);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CampaignApi : ICampaignApi
    {
        private Salesforce.MarketingCloud.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignApi(String authBasePath, string clientId, string clientSecret, string accountId)
        {
            this.Configuration = new Salesforce.MarketingCloud.Client.Configuration
            {
                AuthenticationInstanceUrl = authBasePath,
                ClientId = clientId,
                ClientSecret = clientSecret,
                AccountId = accountId
            };

            var defaultDateTimeProvider = new DefaultDateTimeProvider();
            var cacheService = new CacheService(defaultDateTimeProvider);
            var apiClient = new ApiClient(authBasePath);
            var authService = new AuthService(this.Configuration, apiClient, cacheService);

            this.Configuration.ApiClient.RestClient.Authenticator =
                new Salesforce.MarketingCloud.Authentication.OAuth2Authenticator(authService);

            ExceptionFactory = Salesforce.MarketingCloud.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignApi"/> class.
        /// </summary>
        /// <returns></returns>
        internal CampaignApi(String authBasePath, string clientId, string clientSecret, string accountId, IAuthenticator authenticator)
            : this(authBasePath, clientId, clientSecret, accountId)
        {
            this.Configuration.ApiClient.RestClient.Authenticator = authenticator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CampaignApi(Salesforce.MarketingCloud.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Salesforce.MarketingCloud.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Salesforce.MarketingCloud.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Salesforce.MarketingCloud.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Salesforce.MarketingCloud.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// createCampaign Creates a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">JSON Parameters (optional)</param>
        /// <returns>Campaign</returns>
        public Campaign CreateCampaign (Campaign body = null)
        {
             ApiResponse<Campaign> localVarResponse = CreateCampaignWithHttpInfo(body);
             return localVarResponse.Data;
        }

        /// <summary>
        /// createCampaign Creates a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">JSON Parameters (optional)</param>
        /// <returns>ApiResponse of Campaign</returns>
        public ApiResponse< Campaign > CreateCampaignWithHttpInfo (Campaign body = null)
        {

            var localVarPath = "/hub/v1/campaigns";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateCampaign", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Campaign>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Campaign) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Campaign)));
        }

        /// <summary>
        /// createCampaign Creates a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">JSON Parameters (optional)</param>
        /// <returns>Task of Campaign</returns>
        public async System.Threading.Tasks.Task<Campaign> CreateCampaignAsync (Campaign body = null)
        {
             ApiResponse<Campaign> localVarResponse = await CreateCampaignAsyncWithHttpInfo(body);
             return localVarResponse.Data;

        }

        /// <summary>
        /// createCampaign Creates a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">JSON Parameters (optional)</param>
        /// <returns>Task of ApiResponse (Campaign)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Campaign>> CreateCampaignAsyncWithHttpInfo (Campaign body = null)
        {

            var localVarPath = "/hub/v1/campaigns";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateCampaign", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Campaign>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Campaign) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Campaign)));
        }

        /// <summary>
        /// deleteCampaign Deletes a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The ID of the campaign to delete</param>
        /// <returns></returns>
        public void DeleteCampaignById (decimal? id)
        {
             DeleteCampaignByIdWithHttpInfo(id);
        }

        /// <summary>
        /// deleteCampaign Deletes a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The ID of the campaign to delete</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeleteCampaignByIdWithHttpInfo (decimal? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CampaignApi->DeleteCampaignById");

            var localVarPath = "/hub/v1/campaigns/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteCampaignById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// deleteCampaign Deletes a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The ID of the campaign to delete</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteCampaignByIdAsync (decimal? id)
        {
             await DeleteCampaignByIdAsyncWithHttpInfo(id);

        }

        /// <summary>
        /// deleteCampaign Deletes a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The ID of the campaign to delete</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DeleteCampaignByIdAsyncWithHttpInfo (decimal? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CampaignApi->DeleteCampaignById");

            var localVarPath = "/hub/v1/campaigns/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteCampaignById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// getCampaign Retrieves a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Campaign ID</param>
        /// <returns>Campaign</returns>
        public Campaign GetCampaignById (decimal? id)
        {
             ApiResponse<Campaign> localVarResponse = GetCampaignByIdWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// getCampaign Retrieves a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Campaign ID</param>
        /// <returns>ApiResponse of Campaign</returns>
        public ApiResponse< Campaign > GetCampaignByIdWithHttpInfo (decimal? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CampaignApi->GetCampaignById");

            var localVarPath = "/hub/v1/campaigns/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetCampaignById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Campaign>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Campaign) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Campaign)));
        }

        /// <summary>
        /// getCampaign Retrieves a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Campaign ID</param>
        /// <returns>Task of Campaign</returns>
        public async System.Threading.Tasks.Task<Campaign> GetCampaignByIdAsync (decimal? id)
        {
             ApiResponse<Campaign> localVarResponse = await GetCampaignByIdAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// getCampaign Retrieves a campaign.
        /// </summary>
        /// <exception cref="Salesforce.MarketingCloud.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Campaign ID</param>
        /// <returns>Task of ApiResponse (Campaign)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Campaign>> GetCampaignByIdAsyncWithHttpInfo (decimal? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CampaignApi->GetCampaignById");

            var localVarPath = "/hub/v1/campaigns/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetCampaignById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Campaign>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Campaign) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Campaign)));
        }

    }
}
