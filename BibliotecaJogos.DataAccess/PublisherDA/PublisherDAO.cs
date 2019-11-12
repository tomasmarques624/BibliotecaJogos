using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DataAccess.PublisherDA
{
    public class PublisherDAO
    {
        public static Publisher GetPublisher(int id_publisher)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPublisherByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_publisher", id_publisher);
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            if (Convert.ToInt32(dataReader["ReturnCode"]) == -1)
                            {
                                return null;
                            }
                            if (dataReader.NextResult())
                            {
                                dataReader.Read();
                                Publisher publisher = new Publisher()
                                {
                                    id_publisher = Convert.ToInt32(dataReader["id_publisher"]),
                                    name_publisher = dataReader["name_publisher"].ToString()
                                };
                                return publisher;
                            }
                        }
                        return null;
                    }
                }
            }
        }
        public static int UpdatePublisher(Publisher publisher)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePublisherByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_publisher", publisher.id_publisher);
                    command.Parameters.AddWithValue("@name_publisher", publisher.name_publisher);
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
        public static int DeletePublisher(int id_publisher)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeletePublisherByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_publisher", id_publisher);
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
        public static int InsertPublisher(Publisher publisher)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPublisher";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name_publisher", publisher.name_publisher);
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
        public static List<Publisher> getPublishers()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPublishers";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Publisher> listPublishers = new List<Publisher>();
                            while (dataReader.Read())
                            {
                                listPublishers.Add(new Publisher() {
                                    id_publisher = Convert.ToInt32(dataReader["id_publisher"]),
                                    name_publisher = dataReader["name_publisher"].ToString()
                                });
                            }
                            return listPublishers;
                        }
                        return null;
                    }
                }
            }
        }
    }
}
