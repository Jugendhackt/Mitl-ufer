# MitlUferPublicApi.DefaultApi

All URIs are relative to *http://172.22.42.100:8080*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createAccountPost**](DefaultApi.md#createAccountPost) | **POST** /createAccount | adds an user
[**loginPost**](DefaultApi.md#loginPost) | **POST** /login | Logs you in
[**userPut**](DefaultApi.md#userPut) | **PUT** /user | changes your user
[**usersGetAllGet**](DefaultApi.md#usersGetAllGet) | **GET** /users/getAll | Returns all users
[**usersGetSearchGet**](DefaultApi.md#usersGetSearchGet) | **GET** /users/getSearch | searches user Database


<a name="createAccountPost"></a>
# **createAccountPost**
> createAccountPost(opts)

adds an user

Adds an user to the system

### Example
```javascript
var MitlUferPublicApi = require('mitl_ufer_public_api');

var apiInstance = new MitlUferPublicApi.DefaultApi();
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
apiInstance.createAccountPost(opts, callback);
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

<a name="loginPost"></a>
# **loginPost**
> loginPost(opts)

Logs you in

Creates a cookie providing authentication

### Example
```javascript
var MitlUferPublicApi = require('mitl_ufer_public_api');

var apiInstance = new MitlUferPublicApi.DefaultApi();
var opts = {
  'username': "username_example", // String | the username you entered on Account creation
  'password': "password_example" // String | the password you choose
};
var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.loginPost(opts, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **username** | **String**| the username you entered on Account creation | [optional] 
 **password** | **String**| the password you choose | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

<a name="userPut"></a>
# **userPut**
> userPut(opts)

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
apiInstance.userPut(opts, callback);
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

<a name="usersGetAllGet"></a>
# **usersGetAllGet**
> [User] usersGetAllGet()

Returns all users

By passing in the appropriate options, you can search for available inventory in the system

### Example
```javascript
var MitlUferPublicApi = require('mitl_ufer_public_api');

var apiInstance = new MitlUferPublicApi.DefaultApi();
var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
};
apiInstance.usersGetAllGet(callback);
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**[User]**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

<a name="usersGetSearchGet"></a>
# **usersGetSearchGet**
> [User] usersGetSearchGet(opts)

searches user Database

By passing in the appropriate options, you can search for available inventory in the system 

### Example
```javascript
var MitlUferPublicApi = require('mitl_ufer_public_api');

var apiInstance = new MitlUferPublicApi.DefaultApi();
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
apiInstance.usersGetSearchGet(opts, callback);
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
