using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OwinSelfHost.Services
{
    public class Service
    {
        private HttpClient client = new HttpClient();
        public Service(HttpClient httpClient) { 

        }
        public List<EmployeeModel> getAllEmployees() {

            List<EmployeeModel> employees = new List<EmployeeModel>();
            var task = client.GetAsync(Configuration.URL_GET_ALL_EMPLOYEES)
                .ContinueWith((taskwithresponse) =>
                {
                    var response = taskwithresponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(jsonString.Result);

                });
            task.Wait();
            return employees;
        }
    }
}
