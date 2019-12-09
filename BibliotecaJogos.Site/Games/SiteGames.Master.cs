using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "U")
            {
                navLinkEditPublisher.Attributes["style"] = "display:none";
                navLinkEditGenre.Attributes["style"] = "display:none";
                navLinkUsers.Attributes["style"] = "display:none";
            }
        }

        protected void buttonLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Authentication/Login.aspx");
        }

        protected void buttonLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Authentication/Login.aspx");
        }
    }
}