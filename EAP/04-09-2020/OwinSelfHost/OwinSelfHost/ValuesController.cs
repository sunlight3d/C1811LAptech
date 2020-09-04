using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHost
{
    public class ValuesController: ApiController
    {
        /*
        public string Get() {
            return "Heelloo";
        }
        */
        public string Get(String name) {
            return "Hello " + name;
        }
        public DateTime Get() {
            return DateTime.Now;
        }
    }
}
