using _19_08_2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace _19_08_2020.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new List<string>() { "Hoang", "Huy"};
        }
        public IHttpActionResult Get(int page, int max) {
            //return new List<string>() { page.ToString(), max.ToString() };
            //return json ? lam the nao
            return Ok(new Album() { Name = "Tuoi hoc tro", Year=2020});
            //return NotFound();            
            //loi khac

        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Album album)
        {
            //value la gi day ?

            return Ok(new Album() { Name = "Tuoi hoc tro", Year = 2020 });
        }
        [HttpPost]
        public IHttpActionResult ShowDetailAlbum([FromBody]Album album)
        {
            //value la gi day ?

            return Ok(new Album() { Name = "Tuoi hoc tro", Year = 2020 });
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
