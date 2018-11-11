/*
 * Mitl-ufer public API
 *
 * This is the public API of Mitl-ufer
 *
 * OpenAPI spec version: 1.0.0
 * Contact: tobrohl@gmail.com
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Rewrite.Internal;
using MySql.Data.MySqlClient;
using Org.OpenAPITools.Attributes;
using Org.OpenAPITools.Models;

namespace Org.OpenAPITools.Controllers {
	/// <summary>
	/// 
	/// </summary>
	public class DefaultApiController : Controller {
		/// <summary>
		/// adds an user
		/// </summary>
		/// <remarks>Adds an user to the system</remarks>
		/// <param name="userprofile">The userprofile to add</param>
		/// <param name="password">The password for the new user</param>
		/// <response code="201">item created</response>
		/// <response code="400">invalid input, object invalid</response>
		/// <response code="409">an existing item already exists</response>
		[HttpPost]
		[Route("/CreateAccount")]
		[ValidateModelState]
		[SwaggerOperation("AddUser")]
		public virtual IActionResult AddUser([FromQuery] User userprofile, [FromQuery] string password) {
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
			MySqlCommand cmd = new MySqlCommand("SELECT PasswordHash FROM users WHERE Username = ?", Program.SqlServer);
			cmd.Parameters.Add("Username", MySqlDbType.VarChar, 63).Value = userprofile.Name;
			MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
			bool exists = false;
			while (mySqlDataReader.Read()) {
				exists = true;
				break;
			}

			mySqlDataReader.Close();
			if (exists) {
				return StatusCode(409);
			}

			long salt = RndLong();

			cmd = new MySqlCommand(
				"INSERT INTO users VALUES (@Name,@Postal,@EMail,@Age,@Picture,@Target,@Niveau,@PasswordHash,@Salt)",
				Program.SqlServer);
			cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 63).Value = userprofile.Name;
			cmd.Parameters.Add("@Postal", MySqlDbType.VarChar, 5).Value = userprofile.Laufort;
			cmd.Parameters.Add("@EMail", MySqlDbType.VarChar, 63).Value = userprofile.EMail;
			cmd.Parameters.Add("@Age", MySqlDbType.VarChar, 63).Value = userprofile.Geburtsdatum;
			cmd.Parameters.Add("@Picture", MySqlDbType.VarChar, 255).Value = userprofile.Profilbild;
			cmd.Parameters.Add("@Target", MySqlDbType.Int32).Value = userprofile.Ziel;
			cmd.Parameters.Add("@Niveau", MySqlDbType.VarChar, 63).Value = userprofile.Laufniveau;
			cmd.Parameters.Add("@PasswordHash", MySqlDbType.VarChar, 63).Value = CalcHash(password, BitConverter.GetBytes(salt));
			cmd.ExecuteNonQuery();
			return StatusCode(200);
#if false
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 409 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(409);


         			
#endif
			throw new NotImplementedException();
		}

		public static byte[] StringToByteArray(string hex) {
			return Enumerable.Range(0, hex.Length)
				.Where(x => x % 2 == 0)
				.Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
				.ToArray();
		}

		/// <summary>
		/// Logs you in
		/// </summary>
		/// <remarks>Creates a cookie providing authentication</remarks>
		/// <param name="username">the username you entered on Account creation</param>
		/// <param name="password">the password you choose</param>
		/// <response code="200">Successfully authenticated. The session ID is returned in a cookie named &#x60;JSESSIONID&#x60;. You need to include this cookie in subsequent requests. </response>
		/// <response code="201">Invalid credentials</response>
		[HttpPost]
		[Route("/login")]
		[ValidateModelState]
		[SwaggerOperation("LogIn")]
		public virtual IActionResult LogIn([FromQuery] string username, [FromQuery] string password) {
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
			MySqlCommand cmd = new MySqlCommand("SELECT Salt FROM users where Username = ?");
			cmd.Parameters.Add("Username", MySqlDbType.Int64).Value = username;
			MySqlDataReader saltReader = cmd.ExecuteReader();
			if (!saltReader.Read()) {
				return StatusCode(201);
			}

			byte[] salt = BitConverter.GetBytes((long) saltReader["Salt"]);
			saltReader.Close();
			byte[] hash = CalcHash(password, salt);
			cmd = new MySqlCommand("SELECT PasswordHash FROM users WHERE Username = ?", Program.SqlServer);
			cmd.Parameters.Add("Username", MySqlDbType.VarChar, 63).Value = username;
			MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
			string dbHashStr = "";
			while (mySqlDataReader.Read()) {
				dbHashStr = mySqlDataReader["PasswordHash"].ToString();
			}
mySqlDataReader.Close();
			//dbHashStr = mySqlDataReader.GetString(0);
			if (!hash.SequenceEqual(StringToByteArray(dbHashStr))) {
				return StatusCode(201);
			}

			long jsessionid = RndLong();
			cmd = new MySqlCommand("UPDATE tokens SET Token = ? WHERE Username = ?;", Program.SqlServer);
			cmd.Parameters.Add("Username", MySqlDbType.VarChar, 63).Value = username;
			cmd.Parameters.Add("Token", SqlDbType.BigInt).Value = jsessionid;
			cmd.ExecuteNonQuery();
			Response.Headers.Add("JSESSIONID", jsessionid.ToString());

			return StatusCode(200);
		}

		private static byte[] CalcHash(string password, byte[] salt) {
			HashAlgorithm hashAlgorithm = new SHA256Managed();
			byte[] hash = hashAlgorithm.ComputeHash(Enumerable.Range(0, 2)
				.SelectMany(x => x == 1 ? Encoding.UTF32.GetBytes(password) : salt).ToArray());
			return hash;
		}

		private static long RndLong() {
			byte[] rndBuffer = new byte[8];
			new Random().NextBytes(rndBuffer);
			long jsessionid = BitConverter.ToInt64(rndBuffer, 0);
			return jsessionid;
		}

		/// <summary>
		/// changes your user
		/// </summary>
		/// <remarks>Changes your own user</remarks>
		/// <param name="newUserData">The new userdata</param>
		/// <response code="201">User updated</response>
		/// <response code="400">invalid input, object invalid</response>
		/// <response code="403">You are not allowed to do that</response>
		[HttpPut]
		[Route("/user")]
		[ValidateModelState]
		[SwaggerOperation("ModifyUser")]
		public virtual IActionResult ModifyUser([FromQuery] User newUserData) {
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
#if false
					if (!Request.Headers.Contains("JSESSIONID")) {
      				return StatusCode(400);
      			}
      
      			if (!long.TryParse(Request.Headers["JSESSIONID"], out long jsessionid)) {
      				return StatusCode(400);
      			}
      
      			if (db[jsessionid].username != newUserData.Name) {
      				return StatusCode(403);
      			}
      
      			//TODO change
      			return StatusCode(200);
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403);


      			
#endif
			throw new NotImplementedException();
		}

		/// <summary>
		/// searches user Database
		/// </summary>
		/// <remarks>By passing in the appropriate options, you can search for available inventory in the system </remarks>
		/// <param name="searchString">pass an optional search string fo</param>
		/// <param name="skip">number of records to skip for pagination</param>
		/// <param name="limit">maximum number of records to return</param>
		/// <response code="200">search results matching criteria</response>
		/// <response code="400">bad input parameter</response>
		[HttpGet]
		[Route("/users/getSearch")]
		[ValidateModelState]
		[SwaggerOperation("SearchUserDatabase")]
		[SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "search results matching criteria")]
		public virtual IActionResult SearchUserDatabase([FromQuery] string searchString, [FromQuery] int? skip,
			[FromQuery] [Range(0, 50)] int? limit) {
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
			List<User> allUsers = GetAllUsers((int) (limit+skip));
			return new ObjectResult(allUsers.Where(x => x.Name.Contains(searchString)).Skip((int) skip).ToList());
			//TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
			// return StatusCode(200, default(List<User>));

			//TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
			return StatusCode(400);

			//TODO: Change the data returned
			//return new ObjectResult(example);
		}

		private static List<User> GetAllUsers(int limit =-1) {
			List<User> allUsers = new List<User>();
			MySqlCommand cmd = new MySqlCommand("SELECT * FROM users ", Program.SqlServer);
			MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
			int i = 0;
			while (mySqlDataReader.Read()) {
				if (i==limit) {
					break;
				}
				allUsers.Add(new User() {
					EMail = (string) mySqlDataReader["EMail"], Name = (string) mySqlDataReader["Username"],
					Ziel = (Int32) mySqlDataReader["Target"], Laufort = (string) mySqlDataReader["Postalcode"],
					Laufniveau = (Models.User.LaufniveauEnum) mySqlDataReader["Laufniveau"], Profilbild = (string) mySqlDataReader["Picture"],
					Geburtsdatum = /*(DateTime.Parse((string) mySqlDataReader["Age"]))*/ new DateTime(1980,1,2)
				});
				i++;
				//		dbHashStr = mySqlDataReader["PasswordHash"].ToString();
			}

			mySqlDataReader.Close();
			return allUsers;
		}

		/// <summary>
		/// Returns all users
		/// </summary>
		/// <remarks>By passing in the appropriate options, you can search for available inventory in the system </remarks>
		/// <response code="200">All users</response>
		[HttpGet]
		[Route("/users/getAll")]
		[ValidateModelState]
		[SwaggerOperation("UsersGetAllGet")]
		[SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "All users")]
		public virtual IActionResult UsersGetAllGet() {
			//TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
			// return StatusCode(200, default(List<User>));

			//TODO: Change the data returned
			//Response.StatusCode = 200;
			//return new StatusCodeResult(200);
			Response.Headers.Add("Access-Control-Allow-Origin", "*");/*
			return new ObjectResult(new List<User>(new[] {
				new User() {
					EMail = "xzy", Laufniveau = Models.User.LaufniveauEnum.AnfaengerEnum, Geburtsdatum = new DateTime(1990, 1, 27),
					Laufort = "32657", Name = "Max Musterman",
					Profilbild = "https://en.wikipedia.org/wiki/Purple#/media/File:Queen_Elizabeth_II_in_March_2015.jpg", Ziel = 20
				},
				new User() {
					EMail = "xzy", Laufniveau = Models.User.LaufniveauEnum.AnfaengerEnum, Geburtsdatum = new DateTime(1990, 1, 27),
					Laufort = "32657", Name = "Max Leer",
					Profilbild = "https://en.wikipedia.org/wiki/Purple#/media/File:Queen_Elizabeth_II_in_March_2015.jpg", Ziel = 20
				}
			}));*/
			return new ObjectResult(GetAllUsers());
		}
	}
}