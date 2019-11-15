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

namespace BibliotecaJogos.Site.Games.GamePL
{
    public partial class DetailsGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id_game = Convert.ToInt32(Request.QueryString["id_game"]);
                if(id_game == 0)
                {
                    Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
                }
                Game game = GameDAO.GetGame(id_game);
                lbAmountPaid.Text = game.amount_paid.ToString();
                Genre genre = GenreDAO.GetGenre(game.id_genre);
                Publisher publisher = PublisherDAO.GetPublisher(game.id_publisher);
                lbGenre.Text = genre.description_genre;
                lbPublisher.Text = publisher.name_publisher;
                lbTitle.Text = game.title;
                lbPurchaseDate.Text = Convert.ToDateTime(game.purchase_date).ToString("dd-MM-yyyy");
                imageCapa.ImageUrl = "../../Content/CoverImages/" + game.cover_image;
            }
        }

        protected void btCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}