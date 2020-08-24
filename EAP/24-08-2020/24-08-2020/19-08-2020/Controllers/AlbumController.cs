using _19_08_2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _19_08_2020.Controllers
{
    public class AlbumController : ApiController
    {
        static readonly AlbumRepository albumRepository = new AlbumRepository();
        // GET: api/Album
        public IEnumerable<Album> Get() => albumRepository.GetAll();        

        // GET: api/Album/5
        [Authorize]
        public Album Get(int id)
        {
            
            Album album = albumRepository.Get(id);
            if (album == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return album;
        }

        public IEnumerable<Album> GetElbumByGenre(String genre) {
            return albumRepository.GetAll().Where(album => string.Equals(
                album.Genre, genre, StringComparison.OrdinalIgnoreCase));

        }
        // POST: api/Album
        public void Post([FromBody]Album album)
        {
            albumRepository.Add(album);            
        }

        // PUT: api/Album/5
        public void Put(int id, [FromBody]Album album)
        {
            album.Id = id;
            albumRepository.Update(album);
        }


        // DELETE: api/Album/5
        public void Delete(int id)
        {            
            albumRepository.Remove(id);
        }
    }
}
