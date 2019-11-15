using Biblioteca.Models;
using BibliotecaJogos.DataAccess.GameDA;
using BibliotecaJogos.DataAccess.GenreDA;
using BibliotecaJogos.DataAccess.PublisherDA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site
{
    public partial class EditGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEditor.DataSource = PublisherDAO.getPublishers();
                ddlEditor.DataValueField = "id_publisher";
                ddlEditor.DataTextField = "name_publisher";
                ddlEditor.DataBind();

                ddlGenero.DataSource = GenreDAO.getGenres();
                ddlGenero.DataValueField = "id_genre";
                ddlGenero.DataTextField = "description_genre";
                ddlGenero.DataBind();

                int id_game = Convert.ToInt32(Request.QueryString["id_game"]);
                if (id_game == 0)
                {
                    Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
                }
                Game game = GameDAO.GetGame(id_game);
                tbxValorPago.Text = game.amount_paid.ToString();
                Genre genre = GenreDAO.GetGenre(game.id_genre);
                Publisher publisher = PublisherDAO.GetPublisher(game.id_publisher);
                ddlGenero.SelectedValue = genre.description_genre;
                ddlEditor.SelectedValue = publisher.name_publisher;
                tbxTitulo.Text = game.title;
                tbxDataCompra.Text = Convert.ToDateTime(game.purchase_date).ToString("yyyy-MM-dd");
                imgCapa.ImageUrl = "../../Content/CoverImages/" + game.cover_image;
            }
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            int id_game = Convert.ToInt32(Request.QueryString["id_game"]);

            if (id_game == 0)
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }

            if (fluCapa.HasFile)
            {
                fluCapa.PostedFile.SaveAs(Server.MapPath("~/Content/CoverImages/") + fluCapa.PostedFile.FileName);
                Game game = new Game()
                {
                    id_game = id_game,
                    title = tbxTitulo.Text,
                    cover_image = Path.GetFileName(fluCapa.PostedFile.FileName),
                    amount_paid = Convert.ToDouble(tbxValorPago.Text),
                    purchase_date = Convert.ToDateTime(tbxDataCompra.Text),
                    id_genre = Convert.ToInt32(ddlGenero.SelectedValue),
                    id_publisher = Convert.ToInt32(ddlEditor.SelectedValue)
                };
            }
            else
            {
                Game game = new Game()
                {
                    id_game = id_game,
                    title = tbxTitulo.Text,
                    cover_image = Path.GetFileName(imgCapa.ImageUrl),
                    amount_paid = Convert.ToDouble(tbxValorPago.Text),
                    purchase_date = Convert.ToDateTime(tbxDataCompra.Text),
                    id_genre = Convert.ToInt32(ddlGenero.SelectedValue),
                    id_publisher = Convert.ToInt32(ddlEditor.SelectedValue)
            };

            int ReturnCode = GameDAO.UpdateGame(game);
                if (ReturnCode == -1){
                    lbMensagem.ForeColor = System.Drawing.Color.Red;
                    lbMensagem.Text = "Edição falhada!";
                }
                else
                {
                    lbMensagem.Text = "Edição feita com sucesso!<br />";
                    lbMensagem.ForeColor = System.Drawing.Color.Green;
                    tbxValorPago.Enabled = false;
                    tbxDataCompra.Enabled = false;
                    tbxTitulo.Enabled = false;
                    imgCapa.Visible = false;
                    fluCapa.Enabled = false;
                    ddlEditor.Enabled = false;
                    ddlGenero.Enabled = false;
                    btCancelar.Visible = false;
                    btSalvar.Visible = false;
                    btCancelar.Visible = false;
                    hlCatalogo.Visible = true;
                }
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}