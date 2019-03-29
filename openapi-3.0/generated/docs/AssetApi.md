# IO.Swagger.Api.AssetApi

All URIs are relative to *www.exacttargetapis.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssetV1ContentAssetsIdGet**](AssetApi.md#assetv1contentassetsidget) | **GET** /asset/v1/content/assets/{id} | getObjectById
[**AssetV1ContentAssetsIdPatch**](AssetApi.md#assetv1contentassetsidpatch) | **PATCH** /asset/v1/content/assets/{id} | patchAsset

<a name="assetv1contentassetsidget"></a>
# **AssetV1ContentAssetsIdGet**
> Asset AssetV1ContentAssetsIdGet (BigDecimal id)

getObjectById

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
    public class AssetV1ContentAssetsIdGetExample
    {
        public void main()
        {
            var apiInstance = new AssetApi();
            var id = 1.2;  // BigDecimal | The ID of the asset

            try
            {
                // getObjectById
                Asset result = apiInstance.AssetV1ContentAssetsIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AssetApi.AssetV1ContentAssetsIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **BigDecimal**| The ID of the asset | 

### Return type

[**Asset**](Asset.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="assetv1contentassetsidpatch"></a>
# **AssetV1ContentAssetsIdPatch**
> Asset AssetV1ContentAssetsIdPatch (BigDecimal id, Asset body = null)

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
    public class AssetV1ContentAssetsIdPatchExample
    {
        public void main()
        {
            var apiInstance = new AssetApi();
            var id = 1.2;  // BigDecimal | The ID of the asset to update
            var body = new Asset(); // Asset |  (optional) 

            try
            {
                // patchAsset
                Asset result = apiInstance.AssetV1ContentAssetsIdPatch(id, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AssetApi.AssetV1ContentAssetsIdPatch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **BigDecimal**| The ID of the asset to update | 
 **body** | [**Asset**](Asset.md)|  | [optional] 

### Return type

[**Asset**](Asset.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
