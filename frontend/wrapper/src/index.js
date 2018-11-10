/**
 * Mitl-ufer public API
 * This is the public API of Mitl-ufer
 *
 * OpenAPI spec version: 1.0.0
 * Contact: tobrohl@gmail.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 *
 * OpenAPI Generator version: 3.3.2
 *
 * Do not edit the class manually.
 *
 */

(function(factory) {
  if (typeof define === 'function' && define.amd) {
    // AMD. Register as an anonymous module.
    define(['ApiClient', 'model/User', 'api/DefaultApi'], factory);
  } else if (typeof module === 'object' && module.exports) {
    // CommonJS-like environments that support module.exports, like Node.
    module.exports = factory(require('./ApiClient'), require('./model/User'), require('./api/DefaultApi'));
  }
}(function(ApiClient, User, DefaultApi) {
  'use strict';

  /**
   * This_is_the_public_API_of_Mitl_ufer.<br>
   * The <code>index</code> module provides access to constructors for all the classes which comprise the public API.
   * <p>
   * An AMD (recommended!) or CommonJS application will generally do something equivalent to the following:
   * <pre>
   * var MitlUferPublicApi = require('index'); // See note below*.
   * var xxxSvc = new MitlUferPublicApi.XxxApi(); // Allocate the API class we're going to use.
   * var yyyModel = new MitlUferPublicApi.Yyy(); // Construct a model instance.
   * yyyModel.someProperty = 'someValue';
   * ...
   * var zzz = xxxSvc.doSomething(yyyModel); // Invoke the service.
   * ...
   * </pre>
   * <em>*NOTE: For a top-level AMD script, use require(['index'], function(){...})
   * and put the application logic within the callback function.</em>
   * </p>
   * <p>
   * A non-AMD browser application (discouraged) might do something like this:
   * <pre>
   * var xxxSvc = new MitlUferPublicApi.XxxApi(); // Allocate the API class we're going to use.
   * var yyy = new MitlUferPublicApi.Yyy(); // Construct a model instance.
   * yyyModel.someProperty = 'someValue';
   * ...
   * var zzz = xxxSvc.doSomething(yyyModel); // Invoke the service.
   * ...
   * </pre>
   * </p>
   * @module index
   * @version 1.0.0
   */
  var exports = {
    /**
     * The ApiClient constructor.
     * @property {module:ApiClient}
     */
    ApiClient: ApiClient,
    /**
     * The User model constructor.
     * @property {module:model/User}
     */
    User: User,
    /**
     * The DefaultApi service constructor.
     * @property {module:api/DefaultApi}
     */
    DefaultApi: DefaultApi
  };

  return exports;
}));
