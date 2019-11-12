using Biblioteca.Models;
using BibliotecaJogos.DataAccess.GenreDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.GenrePL
{
    public partial class NewGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Genre genre = new Genre()
                {
                    description_genre = tbxDescri.Text
                };

                int returncode = GenreDAO.InsertGenre(genre);

                if (returncode == -1)
                {
                    lbMensagem.ForeColor = System.Drawing.Color.Red;
                    lbMensagem.Text = "Adição falhada!<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    lbMensagem.ForeColor = System.Drawing.Color.Green;
                    lbMensagem.Text = "Adição Efetuada com sucesso!";
                    tbxDescri.Enabled = false;
                    btCancelar.Visible = false;
                    btInserir.Visible = false;
                    hlCatalogo.Visible = true;
                }
            }
        }


        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GenrePL/Genres.aspx");
        }
    }
}