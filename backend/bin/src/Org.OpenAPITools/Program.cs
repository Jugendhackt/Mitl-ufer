using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using MySql.Data.MySqlClient;

namespace Org.OpenAPITools
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program {
        internal static MySqlConnection SqlServer;
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) {
            SqlServer =
                new MySqlConnection(
                    "user id=root;server=localhost;database=test; connection timeout=5");
            SqlServer.Open();
           // "server=localhost;database=testDB;uid=root;pwd=abc123;";
            //SqlServer = new SqlConnection("user id=root;password='your_password';server=localhost;database=test; connection timeout=5");
            //SqlServer.Open();
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create the web host builder.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>IWebHostBuilder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
            string ip = "172.22.42.100";
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls($"http://{ip}:8080/");
        }
    }
}