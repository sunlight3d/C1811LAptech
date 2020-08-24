using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_08_2020.Models
{
    interface IAlbumRepository
    {
        IEnumerable<Album> GetAll();
        Album Get(int id);
        Album Add(Album album);
        void Remove(int id);
        bool Update(Album album);
    }
}
