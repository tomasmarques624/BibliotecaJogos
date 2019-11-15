using Biblioteca.Models;
using BibliotecaJogos.DataAccess.UserDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = tbxUsername.Text;
                string password = tbxPassword.Text;
                User user = UserDAO.GetUser(username, password);
                if(user == null)
                {
                    lbMensagem.Text = "Username e/ou password errado(s)";
                }
                else
                {
                    Session["role"] = user.Role;
                    char a = user.Role;
                    Session["username"] = user.Username;
                    FormsAuthentication.RedirectFromLoginPage("~/Games/GameLibraryPL/GameLibrary.aspx", false);
                }
            }
        }
    }
}