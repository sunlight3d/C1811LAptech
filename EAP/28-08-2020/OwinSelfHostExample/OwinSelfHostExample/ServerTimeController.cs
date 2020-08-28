using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHostExample
{
    public class ServerTimeController : ApiController 
    {
        //http://localhost:9000/api/servertime
        public DateTime Get() {
            return DateTime.Now;
        }
    }
}
