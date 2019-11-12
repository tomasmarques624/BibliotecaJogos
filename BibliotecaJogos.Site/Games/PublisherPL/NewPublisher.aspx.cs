using Biblioteca.Models;
using BibliotecaJogos.DataAccess.PublisherDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.PublisherPL
{
    public partial class NewPublisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Publisher publisher = new Publisher()
                {
                    name_publisher = tbxNome.Text
                };

                int returncode = PublisherDAO.InsertPublisher(publisher);

                if (returncode == -1)
                {
                    lbMensagem.ForeColor = System.Drawing.Color.Red;
                    lbMensagem.Text = "Adição falhada!<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    lbMensagem.ForeColor = System.Drawing.Color.Green;
                    lbMensagem.Text = "Adição Efetuada com sucesso!";
                    tbxNome.Enabled = false;
                    btCancelar.Visible = false;
                    btInserir.Visible = false;
                    hlCatalogo.Visible = true;
                }
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/PublisherPL/Publishers.aspx");
        }
    }
}