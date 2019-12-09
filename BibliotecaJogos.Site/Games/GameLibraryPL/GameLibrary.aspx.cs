using BibliotecaJogos.DataAccess.GameDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.GameLibraryPL
{
    public partial class GameLibrary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                repeaterGameLibrary.DataSource = GameDAO.getGames();
                repeaterGameLibrary.DataBind();
            }
            if (Session["role"].ToString() == "U")
            {
                btNovoJogo.Visible = false;
            }
        }

        protected void btNovoJogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GamePL/NewGame.aspx");
        }
    }
}