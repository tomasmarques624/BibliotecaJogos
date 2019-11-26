using Biblioteca.Models;
using BibliotecaJogos.DataAccess.UserDA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DataAccess.PasswordDA
{
    public class PasswordDAO
    {
        public static string InsertNewResetPwdRequest(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPwdRequest";
                    command.CommandType = CommandType.StoredProcedure;
                    if (UserDAO.GetUserByEmail(email) == null)
                    {
                        return null;
                    }
                    else
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.Read())
                                {
                                    ResetPwdRequests resetPwd = new ResetPwdRequests()
                                    {
                                        id_resetPwdRequest = Convert.ToInt32(dataReader["id_resetPwdRequest"]),
                                        email = dataReader["email"].ToString(),
                                        guid = dataReader["guid"].ToString(),
                                        date_recovery_request = Convert.ToDateTime(dataReader["date_recovery_request"].ToString())
                                    };
                                    MailMessage mailMessage = new MailMessage();
                                    mailMessage.From = new MailAddress("likedat6969@gmail.com");
                                    mailMessage.To.Add(email);
                                    mailMessage.Subject = "Teste";
                                    mailMessage.Body = ""+resetPwd.guid;
                                    mailMessage.IsBodyHtml = true;
                                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                                    smtpClient.EnableSsl = true;
                                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    smtpClient.UseDefaultCredentials = false;
                                    smtpClient.Credentials = new System.Net.NetworkCredential("likedat6969@gmail.com", "teste123456");
                                    smtpClient.Send(mailMessage);
                                }
                            }
                        }
                    } 
                }
            }
        }

        public static int ResetPassword(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ResetPassword";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }

        public static ResetPwdRequests GetNewPwdRequestDataByGUID(string guid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetNewPwdRequestDataByGUID";
                    command.Parameters.AddWithValue("@guid", guid);
                    command.CommandType = CommandType.StoredProcedure;
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
                                ResetPwdRequests pwdRequests = new ResetPwdRequests()
                                {
                                    id_resetPwdRequest = Convert.ToInt32(dataReader["id_resetPwdRequest"]),
                                    email = dataReader["email"].ToString(),
                                    guid = dataReader["guid"].ToString(),
                                    date_recovery_request = Convert.ToDateTime(dataReader["date_recovery_request"].ToString())
                                };
                                return pwdRequests;
                            }
                        }
                        return null;
                    }
                }
            }
        }
        public static int DeletePwdRequestByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeletePwdRequestByEmail";
                    command.Parameters.AddWithValue("@email", email);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    int returncode = (int)command.ExecuteScalar();
                    return returncode;
                }
            }
        }
    }
}
