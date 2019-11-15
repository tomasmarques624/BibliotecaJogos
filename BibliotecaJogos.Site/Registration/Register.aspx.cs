using Biblioteca.Models;
using BibliotecaJogos.DataAccess.UserDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site
{
    public partial class Registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegistar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = new User()
                {
                    Username = tbxUsername.Text,
                    Password = tbxPassword.Text,
                    Role = 'U'
                };
                int returncode = UserDAO.RegisterUser(user);
                if(returncode == -1)
                {
                    lbMensagem.ForeColor = System.Drawing.Color.Red;
                    lbMensagem.Text = "Registo falhado!<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    lbMensagem.ForeColor = System.Drawing.Color.Green;
                    lbMensagem.Text = "Registo Efetuado com sucesso!";

                    tbxUsername.Enabled = false;
                    tbxPassword.Enabled = false;
                    btCancelar.Visible = false;
                    btRegistar.Visible = false;
                }
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Authentication/Login.aspx");
        }
    }
}