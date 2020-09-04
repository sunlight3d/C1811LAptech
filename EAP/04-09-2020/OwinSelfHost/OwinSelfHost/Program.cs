using System;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace OwinSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start OWIN host 
            WebApp.Start<Startup>(url: Configuration.BASE_URL);
            Console.WriteLine("Server is running");
            Console.ReadLine();
            
        }
    }
}
