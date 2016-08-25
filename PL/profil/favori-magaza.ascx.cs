using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class favori_magaza : System.Web.UI.UserControl
    {
        magazaTakipciBll magazaTkpb = new magazaTakipciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            favoriMagazaRepeater.DataSource = magazaTkpb.list(1, 5);
            favoriMagazaRepeater.DataBind();
            if (Request.QueryString["like"] != null)
            {
                magazaTkpb.delete(Request.QueryString["like"], 5);
            }
            favoriMagazaRepeater.DataSource = magazaTkpb.list(1, 5);
            favoriMagazaRepeater.DataBind();
        }
    }
}