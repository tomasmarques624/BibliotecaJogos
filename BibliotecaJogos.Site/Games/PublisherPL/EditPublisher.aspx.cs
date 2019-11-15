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
    public partial class EditPublisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id_publisher = Convert.ToInt32(Request.QueryString["id_publisher"]);
                Publisher publisher = PublisherDAO.GetPublisher(id_publisher);
                tbxNome.Text = publisher.name_publisher;
            }
        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            int id_publisher = Convert.ToInt32(Request.QueryString["id_publisher"]);
            Publisher publisher = new Publisher()
            {
                id_publisher = id_publisher,
                name_publisher = tbxNome.Text
            };
            int ReturnCode = PublisherDAO.UpdatePublisher(publisher);
            if (ReturnCode == -1)
            {
                lbMensagem.ForeColor = System.Drawing.Color.Red;
                lbMensagem.Text = "Edição falhada!";
            }
            else
            {
                lbMensagem.Text = "Edição feita com sucesso!<br />";
                lbMensagem.ForeColor = System.Drawing.Color.Green;
                tbxNome.Enabled = false;
                btSalvar.Visible = false;
                btCancelar.Visible = false;
                hlCatalogo.Visible = true;
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}