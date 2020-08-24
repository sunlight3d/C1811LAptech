using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19_08_2020.Models
{
    public class AlbumRepository : IAlbumRepository
    {
        private List<Album> albums = new List<Album>();
        private int _nextId = 1;
        public AlbumRepository()
        {
            //luu trong memory
            albums.Add(new Album() {                 
                Name = "The band", 
                Genre = "Classic Rock", Year = 2018, Price = 111.0f });              
            albums.Add(new Album() { Name = "Blue print", Genre = "Hiphop", Year = 2018, Price = 112.0f });
        }
        public Album Add(Album album)
        {
            if (album == null) {
                throw new ArgumentNullException("Album is null");                
            }
            album.Id = _nextId + 1;
            albums.Add(album);
            return album;
        }

        public Album Get(int id)
        {
            return albums.FirstOrDefault(album => album.Id == id);
        }

        public IEnumerable<Album> GetAll() => albums;
        
        public void Remove(int id)
        {
            albums.RemoveAll(album => album.Id == id);
        }

        public bool Update(Album album)
        {
            if (album == null)
            {
                throw new ArgumentNullException("Album is null");
            }
            int foundIndex = albums.FindIndex(eachAlbum => eachAlbum.Id == album.Id);
            if (foundIndex < 0) {
                return false;
            }
            Album foundAlbum = albums[foundIndex];
            foundAlbum.Name = album.Name ?? foundAlbum.Name;//?? = elvis operator
            foundAlbum.Genre = album.Genre ?? foundAlbum.Genre;//?? = elvis operator
            foundAlbum.Year = album.Year == 0 ? foundAlbum.Year : album.Year;
            foundAlbum.Price = album.Price == 0 ? foundAlbum.Price : album.Price;

            return true;
        }
    }
}