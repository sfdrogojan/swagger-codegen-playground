# IO.Swagger.Api.AssetApi

All URIs are relative to *https://www.exacttargetapis.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAssetById**](AssetApi.md#getassetbyid) | **GET** /asset/v1/content/assets/{id} | getAssetById
[**PartiallyUpdateAsset**](AssetApi.md#partiallyupdateasset) | **PATCH** /asset/v1/content/assets/{id} | patchAsset


<a name="getassetbyid"></a>
# **GetAssetById**
> Asset GetAssetById (decimal? id)

getAssetById

Gets an asset by ID.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAssetByIdExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: SFMC_OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AssetApi();
            var id = 8.14;  // decimal? | The ID of the asset

            try
            {
                // getAssetById
                Asset result = apiInstance.GetAssetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AssetApi.GetAssetById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **decimal?**| The ID of the asset | 

### Return type

[**Asset**](Asset.md)

### Authorization

[SFMC_OAuth2](../README.md#SFMC_OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="partiallyupdateasset"></a>
# **PartiallyUpdateAsset**
> Asset PartiallyUpdateAsset (decimal? id, Asset body = null)

patchAsset

Updates part of an asset.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PartiallyUpdateAssetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: SFMC_OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AssetApi();
            var id = 8.14;  // decimal? | The ID of the asset to update
            var body = new Asset(); // Asset | JSON Parameters (optional) 

            try
            {
                // patchAsset
                Asset result = apiInstance.PartiallyUpdateAsset(id, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AssetApi.PartiallyUpdateAsset: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **decimal?**| The ID of the asset to update | 
 **body** | [**Asset**](Asset.md)| JSON Parameters | [optional] 

### Return type

[**Asset**](Asset.md)

### Authorization

[SFMC_OAuth2](../README.md#SFMC_OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

