using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace Org.OpenAPITools
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program {
        internal static SqlConnection SqlServer;
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            SqlServer = new SqlConnection("user id=root;password='';server=localhost:3306;Trusted_Connection=yes;database=Test; connection timeout=5");
            //SqlServer.Open();
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create the web host builder.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>IWebHostBuilder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://172.22.42.100:8080/");
    }
}