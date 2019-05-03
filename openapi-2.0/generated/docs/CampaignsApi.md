# IO.Swagger.Api.CampaignsApi

All URIs are relative to *https://www.exacttargetapis.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateCampaign**](CampaignsApi.md#createcampaign) | **POST** /hub/v1/campaigns | createCampaign
[**GetCampaignById**](CampaignsApi.md#getcampaignbyid) | **GET** /hub/v1/campaigns/{id} | getCampaign


<a name="createcampaign"></a>
# **CreateCampaign**
> Campaign CreateCampaign (string name, string description, string campaignCode, string color, bool? favorite)

createCampaign

Creates a campaign.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateCampaignExample
    {
        public void main()
        {
            var apiInstance = new CampaignsApi();
            var name = name_example;  // string | Name of the campaign with a maximum length of 128 characters
            var description = description_example;  // string | Description of the campaign with a maximum length of 512 characters
            var campaignCode = campaignCode_example;  // string | Unique identifier for the campaign with a maximum length of 36 characters
            var color = color_example;  // string | Hex color value
            var favorite = true;  // bool? | Determines if the campaign will be flagged as a favorite

            try
            {
                // createCampaign
                Campaign result = apiInstance.CreateCampaign(name, description, campaignCode, color, favorite);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CampaignsApi.CreateCampaign: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Name of the campaign with a maximum length of 128 characters | 
 **description** | **string**| Description of the campaign with a maximum length of 512 characters | 
 **campaignCode** | **string**| Unique identifier for the campaign with a maximum length of 36 characters | 
 **color** | **string**| Hex color value | 
 **favorite** | **bool?**| Determines if the campaign will be flagged as a favorite | 

### Return type

[**Campaign**](Campaign.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcampaignbyid"></a>
# **GetCampaignById**
> Campaign GetCampaignById (string id)

getCampaign

Retrieves a campaign.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetCampaignByIdExample
    {
        public void main()
        {
            var apiInstance = new CampaignsApi();
            var id = id_example;  // string | Campaign ID

            try
            {
                // getCampaign
                Campaign result = apiInstance.GetCampaignById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CampaignsApi.GetCampaignById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Campaign ID | 

### Return type

[**Campaign**](Campaign.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

