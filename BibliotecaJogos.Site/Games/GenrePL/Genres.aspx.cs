
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
            if (!Page.IsPostBack)
            {
                refresh();
            }
        }

        private void refresh()
        {
                List<Genre> listGenres = GenreDAO.getGenres();
                gvGenreList.DataSource = listGenres;
                gvGenreList.DataBind();
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
            refresh();
        }

        protected void gvGenreList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGenreList.EditIndex = e.NewEditIndex;
            refresh();
        }

        protected void gvGenreList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id_genre = Convert.ToInt32(gvGenreList.Rows[e.RowIndex].Cells[0].Text);
            Genre genre = new Genre
            {
                id_genre = id_genre,
                description_genre = e.NewValues["description_genre"].ToString()
            };
            int ReturnCode = GenreDAO.UpdateGenre(genre);
            if (ReturnCode == -1)
            {
                lbMensagem.ForeColor = System.Drawing.Color.Red;
                lbMensagem.Text = "Edição falhada!";
                gvGenreList.EditIndex = -1;
                refresh();
            }
            else
            {
                lbMensagem.Text = "Edição feita com sucesso!<br />";
                lbMensagem.ForeColor = System.Drawing.Color.Green;
                gvGenreList.EditIndex = -1;
                refresh();
            }
        }

        protected void gvGenreList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

                gvGenreList.EditIndex = -1;
                refresh();
        }
    }
}