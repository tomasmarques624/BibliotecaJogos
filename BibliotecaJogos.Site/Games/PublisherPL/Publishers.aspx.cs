using Biblioteca.Models;
using BibliotecaJogos.DataAccess.PublisherDA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.PublisherPL
{
    public partial class Publishers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            if (!Page.IsPostBack)
            {
                List<Publisher> listPublishers = PublisherDAO.getPublishers();
                gvPublisherList.DataSource = listPublishers;
                gvPublisherList.DataBind();
            }
        }
        protected void gvPublisherList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int returncode = PublisherDAO.DeletePublisher(Convert.ToInt32(gvPublisherList.Rows[e.RowIndex].Cells[0].Text));
            if (returncode == -1)
            {
                lbMensagem.ForeColor = System.Drawing.Color.Red;
                lbMensagem.Text = "Eliminição falhada!<br />Contacte o administrador ou tente novamente...";
            }
            else if (returncode == 2)
            {
                lbMensagem.ForeColor = System.Drawing.Color.Red;
                lbMensagem.Text = "Eliminição falhada!<br />Foram encontrados jogos desta editora.";
            }
            else
            {
                lbMensagem.ForeColor = System.Drawing.Color.Green;
                lbMensagem.Text = "Eliminição Efetuada com sucesso!";
            }
            refresh();
        }

        protected void gvPublisherList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPublisherList.EditIndex = e.NewEditIndex;
            refresh();
            /*string id = gvPublisherList.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("~/Games/PublisherPL/EditPublisher.aspx?id_publisher=" + id);*/
        }

        protected void btNovaEditora_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/PublisherPL/NewPublisher.aspx");
        }

        protected void btVerCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }

        protected void gvPublisherList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id_publisher = Convert.ToInt32(gvPublisherList.Rows[e.RowIndex].Cells[0].Text);
            Publisher publisher = new Publisher()
            {
                id_publisher = id_publisher,
                name_publisher = e.NewValues["name_publisher"].ToString()
            };
            int ReturnCode = PublisherDAO.UpdatePublisher(publisher);
            if (ReturnCode == -1)
            {
                lbMensagem.ForeColor = System.Drawing.Color.Red;
                lbMensagem.Text = "Edição falhada!";
                refresh();
            }
            else
            {
                lbMensagem.Text = "Edição feita com sucesso!<br />";
                lbMensagem.ForeColor = System.Drawing.Color.Green;
                refresh();
            }
        }
    }
}