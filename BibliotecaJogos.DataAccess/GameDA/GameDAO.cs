using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DataAccess.GameDA
{
    public class GameDAO
    {
        public static List<Game> getGames()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    command.CommandText = "sp_GetGames";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Game> listGames = new List<Game>();
                            while (dataReader.Read())
                            {
                                listGames.Add(new Game()
                                {
                                    id_game = Convert.ToInt32(dataReader["id_game"]),
                                    title = dataReader["title"].ToString(),
                                    amount_paid = Convert.ToDouble(dataReader["amount_paid"]),
                                    id_genre = Convert.ToInt32(dataReader["id_genre"]),
                                    id_publisher = Convert.ToInt32(dataReader["id_publisher"]),
                                    cover_image = dataReader["cover_image"].ToString(),
                                    purchase_date = Convert.ToDateTime(dataReader["purchase_date"].ToString())
                                });
                            }
                            return listGames;
                        }
                        return null;
                    }
                }
            }
        }
        public static int InsertGame(Game game)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertGame";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@title", game.title);
                    command.Parameters.AddWithValue("@cover_image", game.cover_image);
                    command.Parameters.AddWithValue("@amount_paid", (object)game.amount_paid ?? SqlMoney.Null);
                    command.Parameters.AddWithValue("@purchase_date", (object)game.purchase_date ?? SqlDateTime.Null);
                    command.Parameters.AddWithValue("@id_publisher", game.id_publisher);
                    command.Parameters.AddWithValue("@id_genre", game.id_genre);
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }

        public static Game GetGame(int id_game)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetGameByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_game", id_game);
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
                                Game game = new Game()
                                {
                                    id_game = Convert.ToInt32(dataReader["id_game"]),
                                    title = dataReader["title"].ToString(),
                                    amount_paid = Convert.ToDouble(dataReader["amount_paid"]),
                                    id_genre = Convert.ToInt32(dataReader["id_genre"]),
                                    id_publisher = Convert.ToInt32(dataReader["id_publisher"]),
                                    cover_image = dataReader["cover_image"].ToString(),
                                    purchase_date = Convert.ToDateTime(dataReader["purchase_date"].ToString())
                                };
                                return game;
                            }
                        }
                        return null;
                    }
                }
            }
        }
    public static int UpdateGame(Game game)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateGameByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_game", game.id_game);
                    command.Parameters.AddWithValue("@title", game.title);
                    command.Parameters.AddWithValue("@cover_image", game.cover_image);
                    command.Parameters.AddWithValue("@amout_paid", (object)game.amount_paid ?? SqlMoney.Null);
                    command.Parameters.AddWithValue("@purchase_date", (object)game.purchase_date ?? SqlDateTime.Null);
                    command.Parameters.AddWithValue("@id_publisher", game.id_publisher);
                    command.Parameters.AddWithValue("@id_genre", game.id_genre);
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
    }
}
