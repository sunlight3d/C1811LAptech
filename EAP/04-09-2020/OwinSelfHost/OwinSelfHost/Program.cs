using System;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using System.Collections.Generic;

namespace OwinSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start OWIN host 
            WebApp.Start<Startup>(url: Configuration.BASE_URL);
            Console.WriteLine("Server is running");
            Services.Service service = new Services.Service(new HttpClient());
            List<EmployeeModel> employees = service.getAllEmployees();
            Console.WriteLine(employees[0].Address);
            int choice = 0;
            while (choice != 4) {
                Console.WriteLine("Enter a choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        Console.WriteLine("Show all employees");
                        break;
                    case 2:
                        Console.WriteLine("Show employee with id");
                        break;
                    case 3:
                        Console.WriteLine("Show all employees");
                        break;
                    case 4:
                        Console.WriteLine("Exit...");
                        break;
                    default:
                        Console.WriteLine("Please select 1, 2,3,4");
                        break;
                }
            }
            
        }
    }
}
