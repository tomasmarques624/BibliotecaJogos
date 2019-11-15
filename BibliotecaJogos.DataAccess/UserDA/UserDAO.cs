using Biblioteca.Models;
using BibliotecaJogos.DataAccess.CryptoHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BibliotecaJogos.DataAccess.UserDA
{
    public class UserDAO
    {
        public static int RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(user.Password));
                    command.Parameters.AddWithValue("@role", 'U');
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
        public static User GetUserByID(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetUserByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_user", id_user);
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
                                User user = new User()
                                {
                                    id_User = Convert.ToInt32(dataReader["id_user"]),
                                    Username = dataReader["username"].ToString(),
                                    Role = dataReader["role"].ToString()[0]
                                };
                                return user;
                            }
                        }
                        return null;
                    }
                }
            }
        }

        public static User GetUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_AuthenticateUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(password));
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
                                User user = new User()
                                {
                                    id_User = Convert.ToInt32(dataReader["id_user"]),
                                    Username = dataReader["username"].ToString(),
                                    Password = dataReader["password"].ToString(),
                                    Role = dataReader["role"].ToString()[0]
                                };
                                return user;
                            }
                        }
                        return null;
                    }
                }
            }
        }

    }

}