
using Biblioteca.Models;
using BibliotecaJogos.DataAccess.GenreDA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.GenrePL
{
    public partial class Genres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                List<Genre> listGenres = GenreDAO.getGenres();
                gvGenreList.DataSource = listGenres;
                gvGenreList.DataBind();
            }
        }

        protected void btNovoGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GenrePL/NewGenre.aspx");
        }

        protected void btVerCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }

        protected void gvGenreList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int returncode = GenreDAO.DeleteGenre(Convert.ToInt32(gvGenreList.Rows[e.RowIndex].Cells[0].Text));
            if (returncode == -1)
            {
                lbMensagem.ForeColor = System.Drawing.Color.Red;
                lbMensagem.Text = "Eliminição falhada!<br />Contacte o administrador ou tente novamente...";
            }else if(returncode == 2){
                lbMensagem.ForeColor = System.Drawing.Color.Red;
                lbMensagem.Text = "Eliminição falhada!<br />Foram encontrados jogos com este género.";
            }
            else
            {
                lbMensagem.ForeColor = System.Drawing.Color.Green;
                lbMensagem.Text = "Eliminição Efetuada com sucesso!";
            }
        }

        protected void gvGenreList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = gvGenreList.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("~/Games/GenrePL/EditGenre.aspx?id_genre=" + id);
        }
    }
}