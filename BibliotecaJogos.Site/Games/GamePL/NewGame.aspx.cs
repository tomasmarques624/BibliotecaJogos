using Biblioteca.Models;
using BibliotecaJogos.DataAccess.GameDA;
using BibliotecaJogos.DataAccess.GenreDA;
using BibliotecaJogos.DataAccess.PublisherDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site
{
    public partial class NewGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlEditor.DataSource = PublisherDAO.getPublishers();
                ddlEditor.DataValueField = "id_publisher";
                ddlEditor.DataTextField = "name_publisher";
                ddlEditor.DataBind();

                ddlGenero.DataSource = GenreDAO.getGenres();
                ddlGenero.DataValueField = "id_genre";
                ddlGenero.DataTextField = "description_genre";
                ddlGenero.DataBind();
            }
        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Game game = new Game()
                {
                    title = tbxTitulo.Text,
                    amount_paid = string.IsNullOrWhiteSpace(tbxValorPago.Text) ? (double?)null : Convert.ToDouble(tbxValorPago.Text),
                    purchase_date = string.IsNullOrWhiteSpace(tbxDataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(tbxDataCompra.Text),
                    id_genre = Convert.ToInt32(ddlGenero.SelectedValue),
                    id_publisher = Convert.ToInt32(ddlEditor.SelectedValue),
                    cover_image = fluCapa.PostedFile.FileName
                };

                int returncode = GameDAO.InsertGame(game);

                if (returncode == -1)
                {
                    lbMensagem.ForeColor = System.Drawing.Color.Red;
                    lbMensagem.Text = "Adição falhada!<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    fluCapa.PostedFile.SaveAs(Server.MapPath("~/Content/CoverImages/") + game.cover_image);

                    lbMensagem.ForeColor = System.Drawing.Color.Green;
                    lbMensagem.Text = "Adição Efetuada com sucesso!";

                    tbxValorPago.Enabled = false;
                    tbxDataCompra.Enabled = false;
                    tbxTitulo.Enabled = false;
                    fluCapa.Enabled = false;
                    ddlEditor.Enabled = false;
                    ddlGenero.Enabled = false;
                    btInserir.Enabled = false;
                    btLimpar.Enabled = false;
                }
            }
        }

        protected void btLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}