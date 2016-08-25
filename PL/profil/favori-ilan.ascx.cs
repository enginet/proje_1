using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class favori : System.Web.UI.UserControl
    {
        ilanFavoriBll favorib = new ilanFavoriBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            favoriIlanRepeater.DataSource = favorib.list(1, 5);
            favoriIlanRepeater.DataBind();

            if (Request.QueryString["like"] != null)
            {
                favorib.delete(Request.QueryString["like"], 5);
            }

            favoriIlanRepeater.DataSource = favorib.list(1, 5);
            favoriIlanRepeater.DataBind();
        }
    }
}