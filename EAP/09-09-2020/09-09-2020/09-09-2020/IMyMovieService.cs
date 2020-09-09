using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _09_09_2020
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyMovieService" in both code and config file together.
    [ServiceContract]
    public interface IMyMovieService
    {
        [OperationContract]
        List<Movie> GetAll();
        [OperationContract]
        List<Movie> Search(string searchString);
        [OperationContract]
        Movie GetById(int id);
        [OperationContract]
        void AddMovie(Movie newMovie);
        [OperationContract]
        void Edit(Movie movie);
        [OperationContract]
        void Delete(int id);
    }
}
