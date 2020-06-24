using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyNhac.models;

namespace QuanLyNhac
{
    class Database
    {
        private const string SERVER_NAME = "DESKTOP-7PS7HG8\\SQLEXPRESS";
        private const string DATABASE_NAME = "MySongs";
        private const string USER_NAME = "sa";
        private const string PASSWORD = "";
        private const String CONNECTION_STRING = "Server=DESKTOP-7PS7HG8\\SQLEXPRESS; Database=master;Integrated Security = SSPI;";
        private static Database database;
        private Database() { }
        public static Database SharedInstance()
        {
            if (database == null)
            {
                database = new Database();
            }
            return database;

        }
        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }
        public List<Song> getSongsByGenreId(int genreId)
        {
            List<Song> songs = new List<Song>();
            using (SqlConnection connection = this.GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Songs WHERE Songs.GenreID = @GenreID;", connection);
                    command.Parameters.Add("@GenreID", SqlDbType.Int).Value = genreId;
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {                        
                    
                        songs.Add(new Song()
                        {
                            ID = Convert.ToInt32(dataReader.GetValue(0)),
                            Title = dataReader.GetValue(1) as string,
                            ArtistName = dataReader.GetValue(2) as string                            
                        });
                    }
                    dataReader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return songs;
                }
            }
            return songs;
        }
        public List<Genre> getAllGenres()
        {
            List<Genre> genres = new List<Genre>();
            using (SqlConnection connection = this.GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Genre;", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {                        
                        genres.Add(new Genre()
                        {
                            ID = Convert.ToInt32(dataReader.GetValue(0)),
                            GenreName = dataReader.GetValue(1) as string,

                        });
                    }
                    dataReader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return genres;
                }
            }
            return genres;
        }
        public Genre getGenreFromName(string genreName)
        {
            Genre department = null;
            using (SqlConnection connection = this.GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(
                        "SELECT * FROM Genre WHERE UPPER(Genre.GenreName) = UPPER(TRIM(@GenreName));"
                        , connection);
                    command.Parameters.Add("@GenreName", SqlDbType.VarChar, 500).Value = genreName;
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {                        
                        department = new Genre()
                        {
                            ID = Convert.ToInt32(dataReader.GetValue(0)),
                            GenreName = dataReader.GetValue(1) as string,

                        };

                    }
                    dataReader.Close();
                    command.Dispose();
                    connection.Close();
                    return department != null ? department : null;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return department;
                }
            }
        }
        public Boolean insertSong(Song song)
        {
            Boolean result = true;
            using (SqlConnection connection = this.GetConnection())
            {
                try
                {
                    string sql = "INSERT INTO Songs(ID, Title, ArtistName, GenreID)" +
                        "VALUES(@ID, @Title, @ArtistName, @GenreID)";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = song.ID;
                    command.Parameters.Add("@Title", SqlDbType.VarChar, 500).Value = song.Title;
                    command.Parameters.Add("@ArtistName", SqlDbType.VarChar, 200).Value = song.ArtistName;
                    command.Parameters.Add("@GenreID", SqlDbType.Int).Value = song.GenreID;
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return false;
                }
            }
            return result;
        }
        public Boolean updateSong(Song newSong)
        {
            Boolean result = true;
            using (SqlConnection connection = this.GetConnection())
            {
                try
                {
                    string sql = "UPDATE Songs SET " +
                        "Title=@Title, ArtistName=@ArtistName, GenreID=@GenreID WHERE ID=@ID";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = newSong.ID;
                    command.Parameters.Add("@Title", SqlDbType.VarChar, 500).Value = newSong.Title;
                    command.Parameters.Add("@ArtistName", SqlDbType.VarChar, 200).Value = newSong.ArtistName;
                    command.Parameters.Add("@GenreID", SqlDbType.Int).Value = newSong.GenreID;
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return false;
                }
            }
            return result;
        }
    }
}
