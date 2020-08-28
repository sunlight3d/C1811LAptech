using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHostExample
{
    public class StringProcessController: ApiController        
    {
        MyDBEntities myDBEntities = new MyDBEntities();
        public string Get()
        {
            return "Hello World";
        }
        
        public string Get(string id)
        {
            return "Hello "+id;
        }

    }
}
