# MitlUferPublicApi.OpenApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**addUser**](OpenApi.md#addUser) | **POST** /CreateAccount | adds an user
[**searchUserDatabase**](OpenApi.md#searchUserDatabase) | **GET** /users | searches user Database


<a name="addUser"></a>
# **addUser**
> addUser(opts)

adds an user

Adds an user to the system

### Example
```javascript
var MitlUferPublicApi = require('mitl_ufer_public_api');

var apiInstance = new MitlUferPublicApi.OpenApi();
var opts = {
  'user': new MitlUferPublicApi.User() // User | User to add
};
var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.addUser(opts, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **user** | [**User**](User.md)| User to add | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

<a name="searchUserDatabase"></a>
# **searchUserDatabase**
> [User] searchUserDatabase(opts)

searches user Database

By passing in the appropriate options, you can search for available inventory in the system 

### Example
```javascript
var MitlUferPublicApi = require('mitl_ufer_public_api');

var apiInstance = new MitlUferPublicApi.OpenApi();
var opts = {
  'searchString': "searchString_example", // String | pass an optional search string fo
  'skip': 56, // Number | number of records to skip for pagination
  'limit': 56 // Number | maximum number of records to return
};
var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
};
apiInstance.searchUserDatabase(opts, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **searchString** | **String**| pass an optional search string fo | [optional] 
 **skip** | **Number**| number of records to skip for pagination | [optional] 
 **limit** | **Number**| maximum number of records to return | [optional] 

### Return type

[**[User]**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

