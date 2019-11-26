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
                        
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("likedat6969@gmail.com");
                        mailMessage.To.Add(email);
                        mailMessage.Subject = "Teste";
                        mailMessage.Body = "";
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
    }
}
