using System;
using Microsoft.Owin.Hosting;
using System.Net.Http;
namespace OwinSelfHostExample
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            const string PORT = "9000";
            const string BASE_ADDRESS = "http://localhost:" + PORT + "/";

            // Start OWIN host 
            using (var server = WebApp.Start<Startup>(url: BASE_ADDRESS))
            {
                // Create HttpClient and make a request to api/values 
                /*
                
                var response = client.GetAsync(BASE_ADDRESS + "api/StringProcess").Result;
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                */
                var response = client.GetAsync(BASE_ADDRESS + "api/servertime").Result;
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("Server is listening on" + PORT);
                Console.ReadLine();
            }

        }
    }
}
