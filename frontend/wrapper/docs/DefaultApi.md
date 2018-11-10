# MitlUferPublicApi.DefaultApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**loginPost**](DefaultApi.md#loginPost) | **POST** /login | Logs you in
[**modifyUser**](DefaultApi.md#modifyUser) | **PUT** /user | changes your user


<a name="loginPost"></a>
# **loginPost**
> loginPost()

Logs you in

Creates a cookie providing authentication

### Example
```javascript
var MitlUferPublicApi = require('mitl_ufer_public_api');

var apiInstance = new MitlUferPublicApi.DefaultApi();
var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.loginPost(callback);
```

### Parameters
This endpoint does not need any parameter.

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

<a name="modifyUser"></a>
# **modifyUser**
> modifyUser(opts)

changes your user

Changes your own user

### Example
```javascript
var MitlUferPublicApi = require('mitl_ufer_public_api');
var defaultClient = MitlUferPublicApi.ApiClient.instance;
// Configure API key authorization: cookieAuth
var cookieAuth = defaultClient.authentications['cookieAuth'];
cookieAuth.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//cookieAuth.apiKeyPrefix = 'Token';

var apiInstance = new MitlUferPublicApi.DefaultApi();
var opts = {
  'newUserData': new MitlUferPublicApi.User() // User | The new userdata
};
var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.modifyUser(opts, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **newUserData** | [**User**](.md)| The new userdata | [optional] 

### Return type

null (empty response body)

### Authorization

[cookieAuth](../README.md#cookieAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

