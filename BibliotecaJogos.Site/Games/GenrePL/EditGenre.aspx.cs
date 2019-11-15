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
    public partial class EditGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id_genre = Convert.ToInt32(Request.QueryString["id_genre"]);
                Genre genre = GenreDAO.GetGenre(id_genre);
                tbxDescri.Text = genre.description_genre;
            }
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            int id_genre = Convert.ToInt32(Request.QueryString["id_genre"]);
            Genre genre = new Genre
            {
                id_genre = id_genre,
                description_genre = tbxDescri.Text
            };
            int ReturnCode = GenreDAO.UpdateGenre(genre);
            if (ReturnCode == -1)
            {
                lbMensagem.ForeColor = System.Drawing.Color.Red;
                lbMensagem.Text = "Edição falhada!";
            }
            else
            {
                lbMensagem.Text = "Edição feita com sucesso!<br />";
                lbMensagem.ForeColor = System.Drawing.Color.Green;
                tbxDescri.Enabled = false;
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