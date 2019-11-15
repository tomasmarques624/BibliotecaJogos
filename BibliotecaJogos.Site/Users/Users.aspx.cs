using Biblioteca.Models;
using BibliotecaJogos.DataAccess.UserDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Users
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                User user = UserDAO.GetUserByID(Convert.ToInt32(e.Row.Cells[0].Text));
                if(user.Role == 'A')
                {
                    ((CheckBox)e.Row.FindControl("chbxAdmin")).Checked = true;
                }
            }
        }
    }
}