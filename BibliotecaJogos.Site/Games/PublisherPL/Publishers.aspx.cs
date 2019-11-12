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
            if (!Page.IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "sp_GetPublishers";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader sqlDataReader = command.ExecuteReader())
                        {
                            gvPublisherList.DataSource = sqlDataReader;
                            gvPublisherList.DataBind();
                        }
                    }
                }
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
        }

        protected void gvPublisherList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = gvPublisherList.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("~/Games/PublisherPL/EditPublisher.aspx?id_publisher=" + id);
        }

        protected void btNovaEditora_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/PublisherPL/NewPublisher.aspx");
        }

        protected void btVerCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}